using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace AutoMapper.Execution
{
	public static class ProxyGenerator
	{
		private static readonly byte[] privateKey = StringToByteArray("002400000480000094000000060200000024000052534131000400000100010079dfef85ed6ba841717e154f13182c0a6029a40794a6ecd2886c7dc38825f6a4c05b0622723a01cd080f9879126708eef58f134accdc99627947425960ac2397162067507e3c627992aa6b92656ad3380999b30b5d5645ba46cc3fcc6a1de5de7afebcf896c65fb4f9547a6c0c6433045fceccb1fa15e960d519d0cd694b29a4");

		private static readonly byte[] privateKeyToken = StringToByteArray("be96cd2c38ef1005");

		private static readonly MethodInfo delegate_Combine = typeof(Delegate).GetDeclaredMethod("Combine", new Type[2]
		{
			typeof(Delegate),
			typeof(Delegate)
		});

		private static readonly MethodInfo delegate_Remove = typeof(Delegate).GetDeclaredMethod("Remove", new Type[2]
		{
			typeof(Delegate),
			typeof(Delegate)
		});

		private static readonly EventInfo iNotifyPropertyChanged_PropertyChanged = typeof(INotifyPropertyChanged).GetRuntimeEvent("PropertyChanged");

		private static readonly ConstructorInfo proxyBase_ctor = typeof(ProxyBase).GetDeclaredConstructor(new Type[0]);

		private static readonly ModuleBuilder proxyModule = CreateProxyModule();

		private static readonly LockingConcurrentDictionary<TypeDescription, Type> proxyTypes = new LockingConcurrentDictionary<TypeDescription, Type>(EmitProxy);

		private static ModuleBuilder CreateProxyModule()
		{
			AssemblyName assemblyName = new AssemblyName("AutoMapper.Proxies");
			assemblyName.SetPublicKey(privateKey);
			assemblyName.SetPublicKeyToken(privateKeyToken);
			return AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run).DefineDynamicModule("AutoMapper.Proxies.emit");
		}

		private static Type EmitProxy(TypeDescription typeDescription)
		{
			Type type = typeDescription.Type;
			PropertyDescription[] additionalProperties = typeDescription.AdditionalProperties;
			string arg = string.Join("_", additionalProperties.Select((PropertyDescription p) => p.Name));
			string name = string.Format("Proxy{0}<{1}>", arg, Regex.Replace(type.AssemblyQualifiedName ?? type.FullName ?? type.Name, "[\\s,]+", "_"));
			List<Type> list = new List<Type>
			{
				type
			};
			list.AddRange(type.GetTypeInfo().ImplementedInterfaces);
			TypeBuilder typeBuilder = proxyModule.DefineType(name, TypeAttributes.Public | TypeAttributes.Sealed, typeof(ProxyBase), (!type.IsInterface()) ? new Type[0] : new Type[1]
			{
				type
			});
			ILGenerator iLGenerator = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[0]).GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			iLGenerator.Emit(OpCodes.Call, proxyBase_ctor);
			iLGenerator.Emit(OpCodes.Ret);
			FieldBuilder fieldBuilder = null;
			if (typeof(INotifyPropertyChanged).IsAssignableFrom(type))
			{
				fieldBuilder = typeBuilder.DefineField("PropertyChanged", typeof(PropertyChangedEventHandler), FieldAttributes.Private);
				MethodBuilder methodBuilder = typeBuilder.DefineMethod("add_PropertyChanged", MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask | MethodAttributes.SpecialName, typeof(void), new Type[1]
				{
					typeof(PropertyChangedEventHandler)
				});
				ILGenerator iLGenerator2 = methodBuilder.GetILGenerator();
				iLGenerator2.Emit(OpCodes.Ldarg_0);
				iLGenerator2.Emit(OpCodes.Dup);
				iLGenerator2.Emit(OpCodes.Ldfld, fieldBuilder);
				iLGenerator2.Emit(OpCodes.Ldarg_1);
				iLGenerator2.Emit(OpCodes.Call, delegate_Combine);
				iLGenerator2.Emit(OpCodes.Castclass, typeof(PropertyChangedEventHandler));
				iLGenerator2.Emit(OpCodes.Stfld, fieldBuilder);
				iLGenerator2.Emit(OpCodes.Ret);
				MethodBuilder methodBuilder2 = typeBuilder.DefineMethod("remove_PropertyChanged", MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Virtual | MethodAttributes.HideBySig | MethodAttributes.VtableLayoutMask | MethodAttributes.SpecialName, typeof(void), new Type[1]
				{
					typeof(PropertyChangedEventHandler)
				});
				ILGenerator iLGenerator3 = methodBuilder2.GetILGenerator();
				iLGenerator3.Emit(OpCodes.Ldarg_0);
				iLGenerator3.Emit(OpCodes.Dup);
				iLGenerator3.Emit(OpCodes.Ldfld, fieldBuilder);
				iLGenerator3.Emit(OpCodes.Ldarg_1);
				iLGenerator3.Emit(OpCodes.Call, delegate_Remove);
				iLGenerator3.Emit(OpCodes.Castclass, typeof(PropertyChangedEventHandler));
				iLGenerator3.Emit(OpCodes.Stfld, fieldBuilder);
				iLGenerator3.Emit(OpCodes.Ret);
				typeBuilder.DefineMethodOverride(methodBuilder, iNotifyPropertyChanged_PropertyChanged.GetAddMethod());
				typeBuilder.DefineMethodOverride(methodBuilder2, iNotifyPropertyChanged_PropertyChanged.GetRemoveMethod());
			}
			List<PropertyDescription> list2 = new List<PropertyDescription>();
			foreach (PropertyDescription item in (from p in list.Where((Type intf) => intf != typeof(INotifyPropertyChanged)).SelectMany((Type intf) => intf.GetProperties())
				select new PropertyDescription(p)).Concat(additionalProperties))
			{
				if (item.CanWrite)
				{
					list2.Insert(0, item);
				}
				else
				{
					list2.Add(item);
				}
			}
			Dictionary<string, PropertyEmitter> dictionary = new Dictionary<string, PropertyEmitter>();
			foreach (PropertyDescription item2 in list2)
			{
				if (dictionary.TryGetValue(item2.Name, out PropertyEmitter value))
				{
					if (value.PropertyType != item2.Type && (item2.CanWrite || !item2.Type.IsAssignableFrom(value.PropertyType)))
					{
						throw new ArgumentException($"The interface has a conflicting property {item2.Name}", "interfaceType");
					}
				}
				else
				{
					dictionary.Add(item2.Name, value = new PropertyEmitter(typeBuilder, item2, fieldBuilder));
				}
			}
			return typeBuilder.CreateType();
		}

		public static Type GetProxyType(Type interfaceType)
		{
			TypeDescription key = new TypeDescription(interfaceType);
			if (!interfaceType.IsInterface())
			{
				throw new ArgumentException("Only interfaces can be proxied", "interfaceType");
			}
			return proxyTypes.GetOrAdd(key);
		}

		public static Type GetSimilarType(Type sourceType, IEnumerable<PropertyDescription> additionalProperties)
		{
			return proxyTypes.GetOrAdd(new TypeDescription(sourceType, additionalProperties));
		}

		private static byte[] StringToByteArray(string hex)
		{
			int length = hex.Length;
			byte[] array = new byte[length / 2];
			for (int i = 0; i < length; i += 2)
			{
				array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			}
			return array;
		}
	}
}
