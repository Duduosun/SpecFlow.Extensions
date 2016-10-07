using OpenQA.Selenium;
using SpecFlow.Extensions.Web.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlow.Extensions.Web
{
    public class GridElement : TableElement
    {
        private List<string> _actualHeader = new List<string>();
        public GridElement(IWebElement element, ByEx columnHeader, ByEx dataRow, string[] columnsToParse=null)
        {
            MapHeadersToIndex(GetGridHeaders(element, columnHeader), columnsToParse);
            _rows = element.FindElements(dataRow);
        }

        private static IEnumerable<IWebElement> GetGridHeaders(IWebElement element, ByEx columnHeader)
        {
            var columnElements = element.FindElements(columnHeader);
            if (columnElements.ToList().Count == 0)
            {
                throw new InvalidCastException("WebElement is not a valid TableElement, no th or td tags in first tr.");
            }
            return columnElements;
        }

        private void MapHeadersToIndex(IEnumerable<IWebElement> headers, string[] columnsToParse)
        {
            int index = 0;
            if (columnsToParse == null)
            {
                foreach (var headerElement in headers)
                {
                    _headerToIndex.Add(headerElement.Text, index);
                    index++;
                }
            }
            else
            {
                foreach (var header in columnsToParse)
                {
                    _headerToIndex.Add(header, index);
                    index++;
                }
                foreach (var headerElement in headers)
                {
                    _actualHeader.Add(headerElement.Text);
                }
            }
        }

        public new bool CompareToTable(Table table)
        {
            return base.CompareToTable(table, 0);
        }

        public new bool CompareToTable(List<string[]> table)
        {
            return base.CompareToTable(table, 0);
        }

        public override int RowDataCount
        {
            get { return _rows.Count(); }
        }
    }
}