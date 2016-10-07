using SpecFlow.Extensions.Framework.ExtensionMethods;
using SpecFlow.Extensions.Framework.Helpers;
using SpecFlow.Extensions.Web.ByWrappers;
using SpecFlow.Extensions.Web.ExtensionMethods;
using SpecFlow.Extensions.WebDriver.PortalDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SpecFlow.Extensions.PageObjects
{
    // default AutoMapper using the Macro implementation
    public class AutoMapper : AutoMapper<Macro> { }

    public class AutoMapper<T> where T : Macro, new()
    {
        public static IList<string> Headers;
        public static IList<IDictionary<string, string>> Rows;
        private static IPortalDriver _driver;
        private static bool _ignoreMissingMembers;

        public static void Fill(Table table, object context, bool ignoreMissingMembers = true)
        {
            _ignoreMissingMembers = ignoreMissingMembers;
            BuildCustomTable(table);
            var contextMembers = GetMembers(context.GetType());
            SetMembers(context, contextMembers, SetMemberValue);
        }

        public static void Fill(Table table, IPortalDriver driver, Page page, bool ignoreMissingMembers = true)
        {
            _ignoreMissingMembers = ignoreMissingMembers;
            BuildCustomTable(table);
            _driver = driver;
            IList<MemberWrapper> pageByExs = GetMembersByEx(page.GetType());
            SetMembers(page, pageByExs, SetMemberValueByEx);
        }

        public static void Fill(Table table, object context, IPortalDriver driver, Page page, bool ignoreMissingMembers = true)
        {
            _ignoreMissingMembers = ignoreMissingMembers;
            BuildCustomTable(table);
            _driver = driver;
            IList<MemberWrapper> pageByExs = GetMembersByEx(page.GetType());
            var contextMembers = GetMembers(context.GetType());
            SetContextAndPageMembers(page, context, contextMembers, pageByExs);
        }

        public static void Fill(object objSource, object objDestination, bool ignoreMissingMembers = true)
        {
            _ignoreMissingMembers = ignoreMissingMembers;
            SetMembers(objSource, objDestination, GetMembers(objSource.GetType()), GetMembers(objDestination.GetType()),
                GetMemberValue, SetMemberValue);
        }

        public static void Fill(object obj, Page page, bool ignoreMissingMembers = true)
        {
            _ignoreMissingMembers = ignoreMissingMembers;
            SetMembers(obj, page, GetMembers(obj.GetType()), GetMembersByEx(page.GetType()),
                GetMemberValue, SetMemberValueByEx);
        }

        public static void Fill(Page page, object obj, bool ignoreMissingMembers = true)
        {
            _ignoreMissingMembers = ignoreMissingMembers;
            SetMembers(page, obj, GetMembersByEx(page.GetType()), GetMembers(obj.GetType()),
                GetMemberValueByEx, SetMemberValue);
        }

        public static ComparisonMismatch Verify(Table table, object context, Func<string, string, bool> compareMethod, bool ignoreMissingMembers = true)
        {
            BuildCustomTable(table);
            return VerifyTableToObject(context, GetMembers, GetMemberValue, compareMethod);
        }

        public static ComparisonMismatch Verify(object context, Table table, Func<string, string, bool> compareMethod, bool ignoreMissingMembers = true)
        {
            BuildCustomTable(table);
            return VerifyObjectToTable(context, GetMembers, GetMemberValue, compareMethod);
        }

        public static ComparisonMismatch Verify(Table table, Page page, IPortalDriver driver, Func<string, string, bool> compareMethod, bool ignoreMissingMembers = true)
        {
            _driver = driver;
            BuildCustomTable(table);
            return VerifyTableToObject(page, GetMembersByEx, GetMemberValueByEx, compareMethod);
        }

        public static ComparisonMismatch Verify(Page page, Table table, IPortalDriver driver, Func<string, string, bool> compareMethod, bool ignoreMissingMembers = true)
        {
            _driver = driver;
            BuildCustomTable(table);
            return VerifyObjectToTable(page, GetMembersByEx, GetMemberValueByEx, compareMethod);
        }

        public static ComparisonMismatch Verify(object context, Page page, IPortalDriver driver, Func<string, string, bool> compareMethod, bool ignoreMissingMembers = true)
        {
            _driver = driver;
            return CompareMembersToMembers(context, page, GetMembers, GetMembersByEx, GetMemberValue, GetMemberValueByEx, compareMethod);
        }

        public static ComparisonMismatch Verify(Page page, object context, IPortalDriver driver, Func<string, string, bool> compareMethod, bool ignoreMissingMembers = true)
        {
            _driver = driver;
            return CompareMembersToMembers(page, context, GetMembersByEx, GetMembers, GetMemberValueByEx, GetMemberValue, compareMethod);
        }

        private static ComparisonMismatch CompareMembersToMembers(object objSource, object objDestination,
            Func<Type, IList<MemberWrapper>> getSourceMembers, Func<Type, IList<MemberWrapper>> getDestinationMembers,
            Func<object, MemberWrapper, object> getSourceMemberValue, Func<object, MemberWrapper, object> getDestinationMemberValue,
            Func<string, string, bool> compareMethod)
        {
            var comparison = new ComparisonMismatch();
            foreach (var member in getSourceMembers(objSource.GetType()))
            {
                var foundMember = getDestinationMembers(objDestination.GetType()).FirstOrDefault(m => m.Name == member.Name);
                if (foundMember == null)
                {
                    if (!_ignoreMissingMembers)
                    {
                        comparison.Add(string.Format("Missing member '{0}'", member.Name));
                    } // else do nothing
                }
                else
                {
                    comparison.Compare(getSourceMemberValue(objSource, member).ToString(), getDestinationMemberValue(objDestination, foundMember).ToString(), compareMethod, "CompareMembersToMembers");
                }
            }
            return comparison;
        }

        private static ComparisonMismatch VerifyTableToObject(object obj,
            Func<Type, IList<MemberWrapper>> getMembers,
            Func<object, MemberWrapper, object> getMemberValue,
            Func<string, string, bool> compareMethod)
        {
            var comparison = new ComparisonMismatch();
            foreach (var row in Rows)
            {
                foreach (var header in Headers)
                {
                    var foundMember = getMembers(obj.GetType()).FirstOrDefault(m => m.Name == header);
                    if (foundMember == null)
                    {
                        if (!_ignoreMissingMembers)
                        {
                            comparison.Add(string.Format("Missing member '{0}'", header));
                        } // else do nothing
                    }
                    else
                    {
                        comparison.Compare(row[header], getMemberValue(obj, foundMember).ToString(), compareMethod, "VerifyTableToObject");
                    }
                }
            }
            return comparison;
        }

        private static ComparisonMismatch VerifyObjectToTable(object obj,
            Func<Type, IList<MemberWrapper>> getMembers,
            Func<object, MemberWrapper, object> getMemberValue,
            Func<string, string, bool> compareMethod)
        {
            var members = getMembers(obj.GetType());
            var comparison = new ComparisonMismatch();
            foreach (var row in Rows)
            {
                foreach (var member in members)
                {
                    comparison.Compare(getMemberValue(obj, member).ToString(), row[member.Name], compareMethod, "VerifyObjectToTable");
                }
            }
            return comparison;
        }

        private static object GetMemberValue(object obj, MemberWrapper member)
        {
            return member.GetValue(obj);
        }

        private static object GetMemberValueByEx(object page, MemberWrapper member)
        {
            ByEx byEx = (ByEx)GetMemberValue(page, member);
            if (byEx.Input == Input.Select)
            {
                return _driver.FindSelect(byEx).Value();
            }
            else
            {
                return _driver.Find(byEx).Value();
            }
        }

        private static void SetContextAndPageMembers(Page page, object context, IList<MemberWrapper> contextMembers, IList<MemberWrapper> pageByExs)
        {
            foreach (var row in Rows)
            {
                foreach (var header in Headers)
                {
                    // context
                    SetMember(context, contextMembers, header, row[header], SetMemberValue);
                    // pageObject
                    SetMember(page, pageByExs, header, row[header], SetMemberValueByEx);
                }
            }
        }

        private static void SetMembers(object obj, IList<MemberWrapper> members, Action<MemberWrapper, object, string> setMemberValue)
        {
            foreach (var row in Rows)
            {
                foreach (var header in Headers)
                {
                    // context
                    SetMember(obj, members, header, row[header], setMemberValue);
                }
            }
        }

        private static void SetMembers(object objSource, object objDestination,
            IList<MemberWrapper> sourceMembers, IList<MemberWrapper> destinationMembers,
            Func<object, MemberWrapper, object> getMemberValue,
            Action<MemberWrapper, object, string> setMemberValue)
        {
            foreach (var member in sourceMembers)
            {
                SetMember(objDestination, destinationMembers, member.Name, (getMemberValue).ToString(), setMemberValue);
            }
        }

        private static void SetMember(object obj, IList<MemberWrapper> members, string memberName, string value, Action<MemberWrapper, object, string> setMember)
        {
            var foundMember = members.FirstOrDefault(m => m.Name == memberName);
            if (foundMember == null)
            {
                if (!_ignoreMissingMembers)
                {
                    throw new MissingMemberException();
                } // else do nothing
            }
            else
            {
                setMember(foundMember, obj, value);
            }
        }

        private static void SetMemberValueByEx(MemberWrapper member, object page, string value)
        {
            _driver.Set((ByEx)(member.GetValue(page)), value);
        }

        private static void SetMemberValue(MemberWrapper member, object obj, string value)
        {
            member.SetValue(obj, value);
        }

        private static IList<MemberWrapper> GetMembersByEx(Type type)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance).Where(member => member.FieldType == typeof(ByEx)).ToList();
            var props = type.GetProperties().Where(member => member.PropertyType == typeof(ByEx)).ToList();
            return WrapMembers(fields, props);
        }

        private static IList<MemberWrapper> GetMembers(Type type)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance).ToList();
            var props = type.GetProperties().ToList();
            return WrapMembers(fields, props);
        }

        private static List<MemberWrapper> WrapMembers(List<FieldInfo> fields, List<PropertyInfo> props)
        {
            List<MemberWrapper> members = new List<MemberWrapper>();
            fields.ForEach(f => members.Add(new FieldWrapper(f)));
            props.ForEach(p => members.Add(new PropertyWrapper(p)));
            return members;
        }

        private static void BuildCustomTable(Table table)
        {
            T macro = new T();
            macro.Format(table);
            Headers = macro.Headers;
            Rows = macro.Rows;
        }
    }
}