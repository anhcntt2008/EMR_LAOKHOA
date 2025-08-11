using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace AutoMapper.Execution
{
	public class PropertyEmitter
	{
		private static readonly MethodInfo ProxyBaseNotifyPropertyChanged = typeof(ProxyBase).GetTypeInfo().DeclaredMethods.Single((MethodInfo m) => m.Name == "NotifyPropertyChanged");

		private readonly FieldBuilder _fieldBuilder;

		private readonly MethodBuilder _getterBuilder;

		private readonly PropertyBuilder _propertyBuilder;

		private readonly MethodBuilder _setterBuilder;

		public Type PropertyType => _propertyBuilder.PropertyType;

		public PropertyEmitter(TypeBuilder owner, PropertyDescription property, FieldBuilder propertyChangedField)
		{
			string name = property.Name;
			Type type = property.Type;
			_fieldBuilder = owner.DefineField($"<{name}>", type, FieldAttributes.Private);
			_propertyBuilder = owner.DefineProperty(name, PropertyAttributes.None, type, null);
			_getterBuilder = owner.DefineMethod($"get_{name}", MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.SpecialName, type, new Type[0]);
			ILGenerator iLGenerator = _getterBuilder.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Ldfld, _fieldBuilder);
			iLGenerator.Emit(OpCodes.Ret);
			_propertyBuilder.SetGetMethod(_getterBuilder);
			if (property.CanWrite)
			{
				_setterBuilder = owner.DefineMethod($"set_{name}", MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.SpecialName, typeof(void), new Type[1]
				{
					type
				});
				ILGenerator iLGenerator2 = _setterBuilder.GetILGenerator();
				iLGenerator2.Emit(OpCodes.Ldarg_0);
				iLGenerator2.Emit(OpCodes.Ldarg_1);
				iLGenerator2.Emit(OpCodes.Stfld, _fieldBuilder);
				if (propertyChangedField != null)
				{
					iLGenerator2.Emit(OpCodes.Ldarg_0);
					iLGenerator2.Emit(OpCodes.Dup);
					iLGenerator2.Emit(OpCodes.Ldfld, propertyChangedField);
					iLGenerator2.Emit(OpCodes.Ldstr, name);
					iLGenerator2.Emit(OpCodes.Call, ProxyBaseNotifyPropertyChanged);
				}
				iLGenerator2.Emit(OpCodes.Ret);
				_propertyBuilder.SetSetMethod(_setterBuilder);
			}
		}

		public MethodBuilder GetGetter(Type requiredType)
		{
			if (requiredType.IsAssignableFrom(PropertyType))
			{
				return _getterBuilder;
			}
			throw new InvalidOperationException("Types are not compatible");
		}

		public MethodBuilder GetSetter(Type requiredType)
		{
			if (PropertyType.IsAssignableFrom(requiredType))
			{
				return _setterBuilder;
			}
			throw new InvalidOperationException("Types are not compatible");
		}
	}
}
