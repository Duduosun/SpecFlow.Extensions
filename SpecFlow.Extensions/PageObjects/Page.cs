using System.Reflection;

namespace SpecFlow.Extensions.PageObjects
{
	public abstract class Page
	{
		private const string DllExtension = ".dll";
		private const string SamePageSubSectionDelimiter = "_";

		public virtual string Uri
		{
			get
			{
				// get assembly name without extension
				var assemblyName = Assembly.GetAssembly(GetType()).ManifestModule.Name;
				assemblyName = assemblyName.Substring(0, assemblyName.Length - DllExtension.Length);

				// get full class name up to underscore division
				var fullClassName = GetType().FullName;
				int subsectionDivider = fullClassName.IndexOf(SamePageSubSectionDelimiter);
				if (subsectionDivider >= 0)
				{
					fullClassName = fullClassName.Substring(0, (fullClassName.Length - subsectionDivider) + 1);
				}

				// remove assembly name from full class name and convert to Uri
				return fullClassName.Replace(string.Format("{0}.", assemblyName), string.Empty).Replace(".", @"/");
			}
		}
	}
}
