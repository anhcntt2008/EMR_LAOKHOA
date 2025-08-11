using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace AutoMapper.XpressionMapper
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resource
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					resourceMan = new ResourceManager("AutoMapper.XpressionMapper.Resource", typeof(Resource).GetTypeInfo().Assembly);
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static string cannotCreateBinaryExpressionFormat => ResourceManager.GetString("cannotCreateBinaryExpressionFormat", resourceCulture);

		internal static string cantRemapExpression => ResourceManager.GetString("cantRemapExpression", resourceCulture);

		internal static string customResolversNotSupported => ResourceManager.GetString("customResolversNotSupported", resourceCulture);

		internal static string expressionMapValueTypeMustMatchFormat => ResourceManager.GetString("expressionMapValueTypeMustMatchFormat", resourceCulture);

		internal static string includeExpressionTooComplex => ResourceManager.GetString("includeExpressionTooComplex", resourceCulture);

		internal static string invalidArgumentCount => ResourceManager.GetString("invalidArgumentCount", resourceCulture);

		internal static string invalidExpErr => ResourceManager.GetString("invalidExpErr", resourceCulture);

		internal static string mappedMemberIsChildOfTheParameterFormat => ResourceManager.GetString("mappedMemberIsChildOfTheParameterFormat", resourceCulture);

		internal static string mapperInfoDictionaryIsNull => ResourceManager.GetString("mapperInfoDictionaryIsNull", resourceCulture);

		internal static string mustBeExpressions => ResourceManager.GetString("mustBeExpressions", resourceCulture);

		internal static string srcMemberCannotBeNullFormat => ResourceManager.GetString("srcMemberCannotBeNullFormat", resourceCulture);

		internal static string typeMappingsDictionaryIsNull => ResourceManager.GetString("typeMappingsDictionaryIsNull", resourceCulture);

		internal Resource()
		{
		}
	}
}
