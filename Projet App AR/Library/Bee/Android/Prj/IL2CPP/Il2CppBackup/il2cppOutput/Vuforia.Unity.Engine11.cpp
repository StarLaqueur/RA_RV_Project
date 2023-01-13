#include "pch-cpp.hpp"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <limits>
#include <stdint.h>



// System.Action`1<Vuforia.Internal.Observers.IObserver>
struct Action_1_t7CB561E778C7EC9F10016AFE222A712D81C9875C;
// System.Collections.Generic.Dictionary`2<System.Int32,Vuforia.Internal.Observers.AnchorInstance>
struct Dictionary_2_tA74B2D3A0B981C070FC5DB672AC4F7BF2640B326;
// System.Collections.Generic.IList`1<Vuforia.Internal.Observers.IObserverComponent>
struct IList_1_t47DAEEB26FFCF68CDC809AB969569B61C8CB5CE4;
// System.Byte[]
struct ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031;
// System.IntPtr[]
struct IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832;
// System.Diagnostics.StackTrace[]
struct StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF;
// System.Action
struct Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07;
// Vuforia.Internal.Observers.AnchorObserver
struct AnchorObserver_t09B3BF82260D94CEDE6A88033A14558CE176ECC8;
// Vuforia.AreaTargetCapture
struct AreaTargetCapture_tF1573FE5455CB577983E0EC51649A86772A375B7;
// Vuforia.Internal.AreaTargetCapture.AreaTargetCaptureFactory
struct AreaTargetCaptureFactory_t58049FE46C467D9CBA2250BC360771647AF7C102;
// Vuforia.Internal.Observers.DeviceObserver
struct DeviceObserver_t567C44DCB098882C1CB8B95C15B7523E7D1D1556;
// System.Collections.IDictionary
struct IDictionary_t6D03155AF1FA9083817AA5B6AD7DEEACC26AB220;
// Vuforia.Internal.Core.IEngine
struct IEngine_t1840136F87C8826E605686CEB7FDA35D257A8C0C;
// Vuforia.IVuAreaTargetCapture
struct IVuAreaTargetCapture_tB73A6F5F49F3FFA3D92D08A7D2A053CD63759529;
// Vuforia.IVuAreaTargetCaptureController
struct IVuAreaTargetCaptureController_t3FE570E6E2F4A007A9703230119EE504EAEA24DF;
// Vuforia.IVuHitTestResults
struct IVuHitTestResults_t6226BD4E75DCD26EC5B7B4DE9BF5CFB8FF783524;
// Vuforia.IVuObserver
struct IVuObserver_t22ED4BEBA650EF19C49791402D4E59873407ADD9;
// System.NotSupportedException
struct NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A;
// System.Runtime.Serialization.SafeSerializationManager
struct SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6;
// System.String
struct String_t;
// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915;
// Vuforia.Internal.ARFoundation.NullARFoundationFacade/<CheckAvailability>d__12
struct U3CCheckAvailabilityU3Ed__12_t5188907BCF113698B49587D9634CF97C3FBA1FC1;
// Vuforia.Internal.ARFoundation.NullARFoundationFacade/<WaitForCameraReady>d__15
struct U3CWaitForCameraReadyU3Ed__15_t8AC5E5E9C1D7D29295D5C1AF688DFE4917BC5878;

IL2CPP_EXTERN_C RuntimeClass* AreaTargetCapture_tF1573FE5455CB577983E0EC51649A86772A375B7_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C const RuntimeMethod* U3CCheckAvailabilityU3Ed__12_System_Collections_IEnumerator_Reset_m0EDB5DFE51EB1A56367AD7BD5B291581CA53B078_RuntimeMethod_var;
IL2CPP_EXTERN_C const RuntimeMethod* U3CWaitForCameraReadyU3Ed__15_System_Collections_IEnumerator_Reset_m45B1A727F7A8E27C70F3FC6E03A20228DFC1D011_RuntimeMethod_var;
struct Exception_t_marshaled_com;
struct Exception_t_marshaled_pinvoke;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Vuforia.Internal.Observers.AObserver
struct AObserver_t2FE41896EDC843041A2E52E4AFAE89FE5F867979  : public RuntimeObject
{
	// System.Collections.Generic.IList`1<Vuforia.Internal.Observers.IObserverComponent> Vuforia.Internal.Observers.AObserver::<Components>k__BackingField
	RuntimeObject* ___U3CComponentsU3Ek__BackingField_0;
	// System.Int32 Vuforia.Internal.Observers.AObserver::<Id>k__BackingField
	int32_t ___U3CIdU3Ek__BackingField_1;
	// Vuforia.Internal.Core.IEngine Vuforia.Internal.Observers.AObserver::<Engine>k__BackingField
	RuntimeObject* ___U3CEngineU3Ek__BackingField_2;
	// System.Action`1<Vuforia.Internal.Observers.IObserver> Vuforia.Internal.Observers.AObserver::OnObserverDestroyed
	Action_1_t7CB561E778C7EC9F10016AFE222A712D81C9875C* ___OnObserverDestroyed_3;
	// System.Boolean Vuforia.Internal.Observers.AObserver::mDisposed
	bool ___mDisposed_4;
};

// Vuforia.AreaTargetCapture
struct AreaTargetCapture_tF1573FE5455CB577983E0EC51649A86772A375B7  : public RuntimeObject
{
	// System.Action Vuforia.AreaTargetCapture::OnCaptureStarted
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___OnCaptureStarted_0;
	// System.Action Vuforia.AreaTargetCapture::OnCapturePaused
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___OnCapturePaused_1;
	// System.Action Vuforia.AreaTargetCapture::OnCaptureResumed
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___OnCaptureResumed_2;
	// System.Action Vuforia.AreaTargetCapture::OnCaptureStopped
	Action_tD00B0A84D7945E50C2DFFC28EFEE6ED44ED2AD07* ___OnCaptureStopped_3;
	// Vuforia.IVuAreaTargetCaptureController Vuforia.AreaTargetCapture::mVuAreaTargetCaptureController
	RuntimeObject* ___mVuAreaTargetCaptureController_4;
	// Vuforia.Internal.Observers.DeviceObserver Vuforia.AreaTargetCapture::mDeviceObserver
	DeviceObserver_t567C44DCB098882C1CB8B95C15B7523E7D1D1556* ___mDeviceObserver_5;
	// Vuforia.Internal.Observers.AnchorObserver Vuforia.AreaTargetCapture::mAnchorObserver
	AnchorObserver_t09B3BF82260D94CEDE6A88033A14558CE176ECC8* ___mAnchorObserver_6;
	// Vuforia.IVuAreaTargetCapture Vuforia.AreaTargetCapture::mAreaTargetCapture
	RuntimeObject* ___mAreaTargetCapture_7;
};

// Vuforia.Internal.AreaTargetCapture.AreaTargetCaptureFactory
struct AreaTargetCaptureFactory_t58049FE46C467D9CBA2250BC360771647AF7C102  : public RuntimeObject
{
};
struct Il2CppArrayBounds;

// System.String
struct String_t  : public RuntimeObject
{
	// System.Int32 System.String::_stringLength
	int32_t ____stringLength_4;
	// System.Char System.String::_firstChar
	Il2CppChar ____firstChar_5;
};

struct String_t_StaticFields
{
	// System.String System.String::Empty
	String_t* ___Empty_6;
};

// System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F  : public RuntimeObject
{
};
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t6D9B272BD21782F0A9A14F2E41F85A50E97A986F_marshaled_com
{
};

// Vuforia.Internal.ARFoundation.NullARFoundationFacade/<CheckAvailability>d__12
struct U3CCheckAvailabilityU3Ed__12_t5188907BCF113698B49587D9634CF97C3FBA1FC1  : public RuntimeObject
{
	// System.Int32 Vuforia.Internal.ARFoundation.NullARFoundationFacade/<CheckAvailability>d__12::<>1__state
	int32_t ___U3CU3E1__state_0;
	// System.Object Vuforia.Internal.ARFoundation.NullARFoundationFacade/<CheckAvailability>d__12::<>2__current
	RuntimeObject* ___U3CU3E2__current_1;
};

// Vuforia.Internal.ARFoundation.NullARFoundationFacade/<WaitForCameraReady>d__15
struct U3CWaitForCameraReadyU3Ed__15_t8AC5E5E9C1D7D29295D5C1AF688DFE4917BC5878  : public RuntimeObject
{
	// System.Int32 Vuforia.Internal.ARFoundation.NullARFoundationFacade/<WaitForCameraReady>d__15::<>1__state
	int32_t ___U3CU3E1__state_0;
	// System.Object Vuforia.Internal.ARFoundation.NullARFoundationFacade/<WaitForCameraReady>d__15::<>2__current
	RuntimeObject* ___U3CU3E2__current_1;
};

// Vuforia.Internal.Observers.ANativeObserver
struct ANativeObserver_t2CAB5C757A45AED4942F0FD9F32FC7919F0B68FD  : public AObserver_t2FE41896EDC843041A2E52E4AFAE89FE5F867979
{
	// Vuforia.IVuObserver Vuforia.Internal.Observers.ANativeObserver::<VuObserver>k__BackingField
	RuntimeObject* ___U3CVuObserverU3Ek__BackingField_5;
};

// System.Boolean
struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22 
{
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;
};

struct Boolean_t09A6377A54BE2F9E6985A8149F19234FD7DDFE22_StaticFields
{
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;
};

// System.Char
struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17 
{
	// System.Char System.Char::m_value
	Il2CppChar ___m_value_0;
};

struct Char_t521A6F19B456D956AF452D926C32709DC03D6B17_StaticFields
{
	// System.Byte[] System.Char::s_categoryForLatin1
	ByteU5BU5D_tA6237BF417AE52AD70CFB4EF24A7A82613DF9031* ___s_categoryForLatin1_3;
};

// System.Int32
struct Int32_t680FF22E76F6EFAD4375103CBBFFA0421349384C 
{
	// System.Int32 System.Int32::m_value
	int32_t ___m_value_0;
};

// System.IntPtr
struct IntPtr_t 
{
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;
};

struct IntPtr_t_StaticFields
{
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;
};

// System.UInt32
struct UInt32_t1833D51FFA667B18A5AA4B8D34DE284F8495D29B 
{
	// System.UInt32 System.UInt32::m_value
	uint32_t ___m_value_0;
};

// System.Void
struct Void_t4861ACF8F4594C3437BB48B6E56783494B843915 
{
	union
	{
		struct
		{
		};
		uint8_t Void_t4861ACF8F4594C3437BB48B6E56783494B843915__padding[1];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=10
struct __StaticArrayInitTypeSizeU3D10_tB5010175CADB4EABB044B4B583C5D61BFF911181 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D10_tB5010175CADB4EABB044B4B583C5D61BFF911181__padding[10];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=12
struct __StaticArrayInitTypeSizeU3D12_t9678BE1C13BAB9E62F12930F5BBC3086458BBC0F 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D12_t9678BE1C13BAB9E62F12930F5BBC3086458BBC0F__padding[12];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=16
struct __StaticArrayInitTypeSizeU3D16_tACB7ABF59CC704E19B13F35EEE7DD0A8043F7287 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D16_tACB7ABF59CC704E19B13F35EEE7DD0A8043F7287__padding[16];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=20
struct __StaticArrayInitTypeSizeU3D20_tB0732BE58EFED775F30259485AECF221635B5BDA 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D20_tB0732BE58EFED775F30259485AECF221635B5BDA__padding[20];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=24
struct __StaticArrayInitTypeSizeU3D24_t72E1006886F4CE29775F0BA40AC9AF9F1F57AE4A 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D24_t72E1006886F4CE29775F0BA40AC9AF9F1F57AE4A__padding[24];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=28
struct __StaticArrayInitTypeSizeU3D28_tEC01C136349E063BE8541A733DFE7A5CB0FB5312 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D28_tEC01C136349E063BE8541A733DFE7A5CB0FB5312__padding[28];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=40
struct __StaticArrayInitTypeSizeU3D40_tB0E8191F574E2508C62A5D177DDC68DF2FB493A9 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D40_tB0E8191F574E2508C62A5D177DDC68DF2FB493A9__padding[40];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=44
struct __StaticArrayInitTypeSizeU3D44_t119E7D382182A7D730D302B04ABDA212DB4643A9 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D44_t119E7D382182A7D730D302B04ABDA212DB4643A9__padding[44];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=52
struct __StaticArrayInitTypeSizeU3D52_t9E1C7E6ACA2208F3DE309FE0D3819EE5BA982767 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D52_t9E1C7E6ACA2208F3DE309FE0D3819EE5BA982767__padding[52];
	};
};

// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=6
struct __StaticArrayInitTypeSizeU3D6_tB5F94EC6D2FFE05C780AC4DAF02B34C1B79250B5 
{
	union
	{
		struct
		{
			union
			{
			};
		};
		uint8_t __StaticArrayInitTypeSizeU3D6_tB5F94EC6D2FFE05C780AC4DAF02B34C1B79250B5__padding[6];
	};
};

// <PrivateImplementationDetails>
struct U3CPrivateImplementationDetailsU3E_t6CA3E6AC4F6398CAD1C250CE3C1FA38B1C52652E  : public RuntimeObject
{
};

struct U3CPrivateImplementationDetailsU3E_t6CA3E6AC4F6398CAD1C250CE3C1FA38B1C52652E_StaticFields
{
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=44 <PrivateImplementationDetails>::0698228BF899CAEAB9A53E5E6C7099E846C44F56432050D234DDF03AD772F139
	__StaticArrayInitTypeSizeU3D44_t119E7D382182A7D730D302B04ABDA212DB4643A9 ___0698228BF899CAEAB9A53E5E6C7099E846C44F56432050D234DDF03AD772F139_0;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=24 <PrivateImplementationDetails>::18689A54C1FF754BE58500B2ED77A6C75B025BE96F6D01FEF89C42DA1C953F34
	__StaticArrayInitTypeSizeU3D24_t72E1006886F4CE29775F0BA40AC9AF9F1F57AE4A ___18689A54C1FF754BE58500B2ED77A6C75B025BE96F6D01FEF89C42DA1C953F34_1;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=10 <PrivateImplementationDetails>::19AE20A57B073E3E8DD45C6F6A4E9AB1076EA3EBFFF28E4AEB58B411472CF994
	__StaticArrayInitTypeSizeU3D10_tB5010175CADB4EABB044B4B583C5D61BFF911181 ___19AE20A57B073E3E8DD45C6F6A4E9AB1076EA3EBFFF28E4AEB58B411472CF994_2;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=40 <PrivateImplementationDetails>::223D6CA32241C349E421A0164F2341E20CC5B65D5A04AA021CFF71D623895570
	__StaticArrayInitTypeSizeU3D40_tB0E8191F574E2508C62A5D177DDC68DF2FB493A9 ___223D6CA32241C349E421A0164F2341E20CC5B65D5A04AA021CFF71D623895570_3;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=20 <PrivateImplementationDetails>::33350F5DA385CE1B8749AEC68BA060CD54EE981968522B5EDF62178537A1FEEE
	__StaticArrayInitTypeSizeU3D20_tB0732BE58EFED775F30259485AECF221635B5BDA ___33350F5DA385CE1B8749AEC68BA060CD54EE981968522B5EDF62178537A1FEEE_4;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=40 <PrivateImplementationDetails>::38809B9974198671140931F729415F3FD75DF68A6398E3486AE3B58554329A63
	__StaticArrayInitTypeSizeU3D40_tB0E8191F574E2508C62A5D177DDC68DF2FB493A9 ___38809B9974198671140931F729415F3FD75DF68A6398E3486AE3B58554329A63_5;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=28 <PrivateImplementationDetails>::499E4F5C84E20C7347E10100E0EC90C1945EA21C7C80809E4F7F474179B39DF6
	__StaticArrayInitTypeSizeU3D28_tEC01C136349E063BE8541A733DFE7A5CB0FB5312 ___499E4F5C84E20C7347E10100E0EC90C1945EA21C7C80809E4F7F474179B39DF6_6;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=16 <PrivateImplementationDetails>::4EDE3546F1189E450DF4D4A2739BE90BEB3B1708B3B9F406B02E0773A92A10FF
	__StaticArrayInitTypeSizeU3D16_tACB7ABF59CC704E19B13F35EEE7DD0A8043F7287 ___4EDE3546F1189E450DF4D4A2739BE90BEB3B1708B3B9F406B02E0773A92A10FF_7;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=52 <PrivateImplementationDetails>::5857EE4CE98BFABBD62B385C1098507DD0052FF3951043AAD6A1DABD495F18AA
	__StaticArrayInitTypeSizeU3D52_t9E1C7E6ACA2208F3DE309FE0D3819EE5BA982767 ___5857EE4CE98BFABBD62B385C1098507DD0052FF3951043AAD6A1DABD495F18AA_8;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=24 <PrivateImplementationDetails>::5DDF815AC046E7D4603FA586D1BDE42118AD4FE9875D64F716BC7D2740EE52C9
	__StaticArrayInitTypeSizeU3D24_t72E1006886F4CE29775F0BA40AC9AF9F1F57AE4A ___5DDF815AC046E7D4603FA586D1BDE42118AD4FE9875D64F716BC7D2740EE52C9_9;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=16 <PrivateImplementationDetails>::605A3F93AE7A97E00C156F977E942027EA532E263A5B440A4219984F803FDD04
	__StaticArrayInitTypeSizeU3D16_tACB7ABF59CC704E19B13F35EEE7DD0A8043F7287 ___605A3F93AE7A97E00C156F977E942027EA532E263A5B440A4219984F803FDD04_10;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=12 <PrivateImplementationDetails>::65FE3B9CCEB336F4BC478829A470BA32E7133B377449716BF3D1FE5D21592D19
	__StaticArrayInitTypeSizeU3D12_t9678BE1C13BAB9E62F12930F5BBC3086458BBC0F ___65FE3B9CCEB336F4BC478829A470BA32E7133B377449716BF3D1FE5D21592D19_11;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=40 <PrivateImplementationDetails>::7439A4C9E30AC42BCC55AD1A2B617E29E7129B6DDAC79C886944B17819262CC1
	__StaticArrayInitTypeSizeU3D40_tB0E8191F574E2508C62A5D177DDC68DF2FB493A9 ___7439A4C9E30AC42BCC55AD1A2B617E29E7129B6DDAC79C886944B17819262CC1_12;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=6 <PrivateImplementationDetails>::772907508FD7AA0ED404C8FC80B6B772E26D67FA3C3662C22D62B871067C28DA
	__StaticArrayInitTypeSizeU3D6_tB5F94EC6D2FFE05C780AC4DAF02B34C1B79250B5 ___772907508FD7AA0ED404C8FC80B6B772E26D67FA3C3662C22D62B871067C28DA_13;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=40 <PrivateImplementationDetails>::990F3F1286CC3928725497B2745CFF7BC7C9803B4EB8271611540BA6BF6654B5
	__StaticArrayInitTypeSizeU3D40_tB0E8191F574E2508C62A5D177DDC68DF2FB493A9 ___990F3F1286CC3928725497B2745CFF7BC7C9803B4EB8271611540BA6BF6654B5_14;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=16 <PrivateImplementationDetails>::A8636D08B42D058EFC34703DD37B6468FCE56138DF242B862C3F1CA138CB3B89
	__StaticArrayInitTypeSizeU3D16_tACB7ABF59CC704E19B13F35EEE7DD0A8043F7287 ___A8636D08B42D058EFC34703DD37B6468FCE56138DF242B862C3F1CA138CB3B89_15;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=20 <PrivateImplementationDetails>::B1D1BCD1D06B4A563944BE3C67D51F63DF23702E5BE760D7897C6AD1F51C6122
	__StaticArrayInitTypeSizeU3D20_tB0732BE58EFED775F30259485AECF221635B5BDA ___B1D1BCD1D06B4A563944BE3C67D51F63DF23702E5BE760D7897C6AD1F51C6122_16;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=52 <PrivateImplementationDetails>::C72DD2E22CFE4B7A3023394A011364AF88315AA6E10C0F8B4C955F8E17AE1C4C
	__StaticArrayInitTypeSizeU3D52_t9E1C7E6ACA2208F3DE309FE0D3819EE5BA982767 ___C72DD2E22CFE4B7A3023394A011364AF88315AA6E10C0F8B4C955F8E17AE1C4C_17;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=20 <PrivateImplementationDetails>::CAA07D7573596B3356BD202533F0EAFDD05309981F270193A99E300D57587326
	__StaticArrayInitTypeSizeU3D20_tB0732BE58EFED775F30259485AECF221635B5BDA ___CAA07D7573596B3356BD202533F0EAFDD05309981F270193A99E300D57587326_18;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=40 <PrivateImplementationDetails>::D4B3B8EBA0589FC38724A0D318B46104B07BC528744109ED69ED71604B7EEC1A
	__StaticArrayInitTypeSizeU3D40_tB0E8191F574E2508C62A5D177DDC68DF2FB493A9 ___D4B3B8EBA0589FC38724A0D318B46104B07BC528744109ED69ED71604B7EEC1A_19;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=40 <PrivateImplementationDetails>::F6EDC1733B068F457C63E03BB041B9AB6BFAD5CD7673D3E0841968D3FBCB12C7
	__StaticArrayInitTypeSizeU3D40_tB0E8191F574E2508C62A5D177DDC68DF2FB493A9 ___F6EDC1733B068F457C63E03BB041B9AB6BFAD5CD7673D3E0841968D3FBCB12C7_20;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=52 <PrivateImplementationDetails>::FADB218011E7702BB9575D0C32A685DA10B5C72EB809BD9A955DB1C76E4D8315
	__StaticArrayInitTypeSizeU3D52_t9E1C7E6ACA2208F3DE309FE0D3819EE5BA982767 ___FADB218011E7702BB9575D0C32A685DA10B5C72EB809BD9A955DB1C76E4D8315_21;
	// <PrivateImplementationDetails>/__StaticArrayInitTypeSize=40 <PrivateImplementationDetails>::FCA56C548368F7065472C8C8EE4D63921B4F16BB51181EC202A0C252D5209E6A
	__StaticArrayInitTypeSizeU3D40_tB0E8191F574E2508C62A5D177DDC68DF2FB493A9 ___FCA56C548368F7065472C8C8EE4D63921B4F16BB51181EC202A0C252D5209E6A_22;
};

// Vuforia.Internal.Observers.ASingleTargetObserver
struct ASingleTargetObserver_t70CEC9D9A86812A3DA1FB9D4E24BDBE3150BB26A  : public ANativeObserver_t2CAB5C757A45AED4942F0FD9F32FC7919F0B68FD
{
};

// Vuforia.Internal.Observers.AnchorObserver
struct AnchorObserver_t09B3BF82260D94CEDE6A88033A14558CE176ECC8  : public ANativeObserver_t2CAB5C757A45AED4942F0FD9F32FC7919F0B68FD
{
	// System.Collections.Generic.Dictionary`2<System.Int32,Vuforia.Internal.Observers.AnchorInstance> Vuforia.Internal.Observers.AnchorObserver::mAnchorInstances
	Dictionary_2_tA74B2D3A0B981C070FC5DB672AC4F7BF2640B326* ___mAnchorInstances_6;
	// Vuforia.IVuHitTestResults Vuforia.Internal.Observers.AnchorObserver::mHitTestResults
	RuntimeObject* ___mHitTestResults_7;
};

// System.Exception
struct Exception_t  : public RuntimeObject
{
	// System.String System.Exception::_className
	String_t* ____className_1;
	// System.String System.Exception::_message
	String_t* ____message_2;
	// System.Collections.IDictionary System.Exception::_data
	RuntimeObject* ____data_3;
	// System.Exception System.Exception::_innerException
	Exception_t* ____innerException_4;
	// System.String System.Exception::_helpURL
	String_t* ____helpURL_5;
	// System.Object System.Exception::_stackTrace
	RuntimeObject* ____stackTrace_6;
	// System.String System.Exception::_stackTraceString
	String_t* ____stackTraceString_7;
	// System.String System.Exception::_remoteStackTraceString
	String_t* ____remoteStackTraceString_8;
	// System.Int32 System.Exception::_remoteStackIndex
	int32_t ____remoteStackIndex_9;
	// System.Object System.Exception::_dynamicMethods
	RuntimeObject* ____dynamicMethods_10;
	// System.Int32 System.Exception::_HResult
	int32_t ____HResult_11;
	// System.String System.Exception::_source
	String_t* ____source_12;
	// System.Runtime.Serialization.SafeSerializationManager System.Exception::_safeSerializationManager
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	// System.Diagnostics.StackTrace[] System.Exception::captured_traces
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	// System.IntPtr[] System.Exception::native_trace_ips
	IntPtrU5BU5D_tFD177F8C806A6921AD7150264CCC62FA00CAD832* ___native_trace_ips_15;
	// System.Int32 System.Exception::caught_in_unmanaged
	int32_t ___caught_in_unmanaged_16;
};

struct Exception_t_StaticFields
{
	// System.Object System.Exception::s_EDILock
	RuntimeObject* ___s_EDILock_0;
};
// Native definition for P/Invoke marshalling of System.Exception
struct Exception_t_marshaled_pinvoke
{
	char* ____className_1;
	char* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_pinvoke* ____innerException_4;
	char* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	char* ____stackTraceString_7;
	char* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	char* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};
// Native definition for COM marshalling of System.Exception
struct Exception_t_marshaled_com
{
	Il2CppChar* ____className_1;
	Il2CppChar* ____message_2;
	RuntimeObject* ____data_3;
	Exception_t_marshaled_com* ____innerException_4;
	Il2CppChar* ____helpURL_5;
	Il2CppIUnknown* ____stackTrace_6;
	Il2CppChar* ____stackTraceString_7;
	Il2CppChar* ____remoteStackTraceString_8;
	int32_t ____remoteStackIndex_9;
	Il2CppIUnknown* ____dynamicMethods_10;
	int32_t ____HResult_11;
	Il2CppChar* ____source_12;
	SafeSerializationManager_tCBB85B95DFD1634237140CD892E82D06ECB3F5E6* ____safeSerializationManager_13;
	StackTraceU5BU5D_t32FBCB20930EAF5BAE3F450FF75228E5450DA0DF* ___captured_traces_14;
	Il2CppSafeArray/*NONE*/* ___native_trace_ips_15;
	int32_t ___caught_in_unmanaged_16;
};

// Vuforia.Internal.Observers.DeviceObserver
struct DeviceObserver_t567C44DCB098882C1CB8B95C15B7523E7D1D1556  : public ASingleTargetObserver_t70CEC9D9A86812A3DA1FB9D4E24BDBE3150BB26A
{
	// System.Boolean Vuforia.Internal.Observers.DeviceObserver::<IsUpdatesDisabled>k__BackingField
	bool ___U3CIsUpdatesDisabledU3Ek__BackingField_6;
};

// System.SystemException
struct SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295  : public Exception_t
{
};

// System.NotSupportedException
struct NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A  : public SystemException_tCC48D868298F4C0705279823E34B00F4FBDB7295
{
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Void System.Object::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2 (RuntimeObject* __this, const RuntimeMethod* method) ;
// System.Void System.NotSupportedException::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void NotSupportedException__ctor_m1398D0CDE19B36AA3DE9392879738C1EA2439CDF (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* __this, const RuntimeMethod* method) ;
// System.Void Vuforia.AreaTargetCapture::.ctor(Vuforia.IVuAreaTargetCaptureController,Vuforia.Internal.Observers.DeviceObserver,Vuforia.Internal.Observers.AnchorObserver)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AreaTargetCapture__ctor_m5726D7F66BC66BD54981C64490A21EB8D7026B17 (AreaTargetCapture_tF1573FE5455CB577983E0EC51649A86772A375B7* __this, RuntimeObject* ___areaTargetCaptureController0, DeviceObserver_t567C44DCB098882C1CB8B95C15B7523E7D1D1556* ___deviceObserver1, AnchorObserver_t09B3BF82260D94CEDE6A88033A14558CE176ECC8* ___anchorObserver2, const RuntimeMethod* method) ;
// System.Char System.String::get_Chars(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Il2CppChar String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3 (String_t* __this, int32_t ___index0, const RuntimeMethod* method) ;
// System.Int32 System.String::get_Length()
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline (String_t* __this, const RuntimeMethod* method) ;
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Vuforia.Internal.ARFoundation.NullARFoundationFacade/<CheckAvailability>d__12::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CCheckAvailabilityU3Ed__12__ctor_m274968FBFFA95FF1D91C3570D01330AF8D1A173E (U3CCheckAvailabilityU3Ed__12_t5188907BCF113698B49587D9634CF97C3FBA1FC1* __this, int32_t ___U3CU3E1__state0, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		int32_t L_0 = ___U3CU3E1__state0;
		__this->___U3CU3E1__state_0 = L_0;
		return;
	}
}
// System.Void Vuforia.Internal.ARFoundation.NullARFoundationFacade/<CheckAvailability>d__12::System.IDisposable.Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CCheckAvailabilityU3Ed__12_System_IDisposable_Dispose_m82CD491E2EB89607DC5F18AAD0080E9F4E256164 (U3CCheckAvailabilityU3Ed__12_t5188907BCF113698B49587D9634CF97C3FBA1FC1* __this, const RuntimeMethod* method) 
{
	{
		return;
	}
}
// System.Boolean Vuforia.Internal.ARFoundation.NullARFoundationFacade/<CheckAvailability>d__12::MoveNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool U3CCheckAvailabilityU3Ed__12_MoveNext_m58AA83F719BA82E28B610968105FC40A6D213A42 (U3CCheckAvailabilityU3Ed__12_t5188907BCF113698B49587D9634CF97C3FBA1FC1* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = __this->___U3CU3E1__state_0;
		V_0 = L_0;
		int32_t L_1 = V_0;
		if (!L_1)
		{
			goto IL_000c;
		}
	}
	{
		return (bool)0;
	}

IL_000c:
	{
		__this->___U3CU3E1__state_0 = (-1);
		return (bool)0;
	}
}
// System.Object Vuforia.Internal.ARFoundation.NullARFoundationFacade/<CheckAvailability>d__12::System.Collections.Generic.IEnumerator<System.Object>.get_Current()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* U3CCheckAvailabilityU3Ed__12_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_mFEA6DA993AA208BF40057885DB1451D265FFE510 (U3CCheckAvailabilityU3Ed__12_t5188907BCF113698B49587D9634CF97C3FBA1FC1* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CU3E2__current_1;
		return L_0;
	}
}
// System.Void Vuforia.Internal.ARFoundation.NullARFoundationFacade/<CheckAvailability>d__12::System.Collections.IEnumerator.Reset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CCheckAvailabilityU3Ed__12_System_Collections_IEnumerator_Reset_m0EDB5DFE51EB1A56367AD7BD5B291581CA53B078 (U3CCheckAvailabilityU3Ed__12_t5188907BCF113698B49587D9634CF97C3FBA1FC1* __this, const RuntimeMethod* method) 
{
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_0 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_0);
		NotSupportedException__ctor_m1398D0CDE19B36AA3DE9392879738C1EA2439CDF(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&U3CCheckAvailabilityU3Ed__12_System_Collections_IEnumerator_Reset_m0EDB5DFE51EB1A56367AD7BD5B291581CA53B078_RuntimeMethod_var)));
	}
}
// System.Object Vuforia.Internal.ARFoundation.NullARFoundationFacade/<CheckAvailability>d__12::System.Collections.IEnumerator.get_Current()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* U3CCheckAvailabilityU3Ed__12_System_Collections_IEnumerator_get_Current_m34E68754B2B82B96EDBCD91693382B395327F93E (U3CCheckAvailabilityU3Ed__12_t5188907BCF113698B49587D9634CF97C3FBA1FC1* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CU3E2__current_1;
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void Vuforia.Internal.ARFoundation.NullARFoundationFacade/<WaitForCameraReady>d__15::.ctor(System.Int32)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CWaitForCameraReadyU3Ed__15__ctor_mCA623337929232D427153EB2060D0716D8346A4D (U3CWaitForCameraReadyU3Ed__15_t8AC5E5E9C1D7D29295D5C1AF688DFE4917BC5878* __this, int32_t ___U3CU3E1__state0, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		int32_t L_0 = ___U3CU3E1__state0;
		__this->___U3CU3E1__state_0 = L_0;
		return;
	}
}
// System.Void Vuforia.Internal.ARFoundation.NullARFoundationFacade/<WaitForCameraReady>d__15::System.IDisposable.Dispose()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CWaitForCameraReadyU3Ed__15_System_IDisposable_Dispose_mBF2EA7E92A04A772E51960701BD493D18DA052F7 (U3CWaitForCameraReadyU3Ed__15_t8AC5E5E9C1D7D29295D5C1AF688DFE4917BC5878* __this, const RuntimeMethod* method) 
{
	{
		return;
	}
}
// System.Boolean Vuforia.Internal.ARFoundation.NullARFoundationFacade/<WaitForCameraReady>d__15::MoveNext()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR bool U3CWaitForCameraReadyU3Ed__15_MoveNext_m8E3CD86CE029DA8D9903482CE015356FD6955E54 (U3CWaitForCameraReadyU3Ed__15_t8AC5E5E9C1D7D29295D5C1AF688DFE4917BC5878* __this, const RuntimeMethod* method) 
{
	int32_t V_0 = 0;
	{
		int32_t L_0 = __this->___U3CU3E1__state_0;
		V_0 = L_0;
		int32_t L_1 = V_0;
		if (!L_1)
		{
			goto IL_000c;
		}
	}
	{
		return (bool)0;
	}

IL_000c:
	{
		__this->___U3CU3E1__state_0 = (-1);
		return (bool)0;
	}
}
// System.Object Vuforia.Internal.ARFoundation.NullARFoundationFacade/<WaitForCameraReady>d__15::System.Collections.Generic.IEnumerator<System.Object>.get_Current()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* U3CWaitForCameraReadyU3Ed__15_System_Collections_Generic_IEnumeratorU3CSystem_ObjectU3E_get_Current_mA0C7852010507EB06BF4F7267E450CB19F10227E (U3CWaitForCameraReadyU3Ed__15_t8AC5E5E9C1D7D29295D5C1AF688DFE4917BC5878* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CU3E2__current_1;
		return L_0;
	}
}
// System.Void Vuforia.Internal.ARFoundation.NullARFoundationFacade/<WaitForCameraReady>d__15::System.Collections.IEnumerator.Reset()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void U3CWaitForCameraReadyU3Ed__15_System_Collections_IEnumerator_Reset_m45B1A727F7A8E27C70F3FC6E03A20228DFC1D011 (U3CWaitForCameraReadyU3Ed__15_t8AC5E5E9C1D7D29295D5C1AF688DFE4917BC5878* __this, const RuntimeMethod* method) 
{
	{
		NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A* L_0 = (NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A*)il2cpp_codegen_object_new(((RuntimeClass*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&NotSupportedException_t1429765983D409BD2986508963C98D214E4EBF4A_il2cpp_TypeInfo_var)));
		NullCheck(L_0);
		NotSupportedException__ctor_m1398D0CDE19B36AA3DE9392879738C1EA2439CDF(L_0, NULL);
		IL2CPP_RAISE_MANAGED_EXCEPTION(L_0, ((RuntimeMethod*)il2cpp_codegen_initialize_runtime_metadata_inline((uintptr_t*)&U3CWaitForCameraReadyU3Ed__15_System_Collections_IEnumerator_Reset_m45B1A727F7A8E27C70F3FC6E03A20228DFC1D011_RuntimeMethod_var)));
	}
}
// System.Object Vuforia.Internal.ARFoundation.NullARFoundationFacade/<WaitForCameraReady>d__15::System.Collections.IEnumerator.get_Current()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR RuntimeObject* U3CWaitForCameraReadyU3Ed__15_System_Collections_IEnumerator_get_Current_mBC28B89899E6115AFBDC54330EDFA16E4BE1249F (U3CWaitForCameraReadyU3Ed__15_t8AC5E5E9C1D7D29295D5C1AF688DFE4917BC5878* __this, const RuntimeMethod* method) 
{
	{
		RuntimeObject* L_0 = __this->___U3CU3E2__current_1;
		return L_0;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// Vuforia.AreaTargetCapture Vuforia.Internal.AreaTargetCapture.AreaTargetCaptureFactory::CreateAreaTargetCapture(Vuforia.IVuAreaTargetCaptureController,Vuforia.Internal.Observers.DeviceObserver,Vuforia.Internal.Observers.AnchorObserver)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR AreaTargetCapture_tF1573FE5455CB577983E0EC51649A86772A375B7* AreaTargetCaptureFactory_CreateAreaTargetCapture_m6F07ED206F1A75C554AA30B52A257FCB6106B178 (AreaTargetCaptureFactory_t58049FE46C467D9CBA2250BC360771647AF7C102* __this, RuntimeObject* ___vuAreaTargetCaptureController0, DeviceObserver_t567C44DCB098882C1CB8B95C15B7523E7D1D1556* ___deviceObserver1, AnchorObserver_t09B3BF82260D94CEDE6A88033A14558CE176ECC8* ___anchorObserver2, const RuntimeMethod* method) 
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_runtime_metadata((uintptr_t*)&AreaTargetCapture_tF1573FE5455CB577983E0EC51649A86772A375B7_il2cpp_TypeInfo_var);
		s_Il2CppMethodInitialized = true;
	}
	{
		RuntimeObject* L_0 = ___vuAreaTargetCaptureController0;
		DeviceObserver_t567C44DCB098882C1CB8B95C15B7523E7D1D1556* L_1 = ___deviceObserver1;
		AnchorObserver_t09B3BF82260D94CEDE6A88033A14558CE176ECC8* L_2 = ___anchorObserver2;
		AreaTargetCapture_tF1573FE5455CB577983E0EC51649A86772A375B7* L_3 = (AreaTargetCapture_tF1573FE5455CB577983E0EC51649A86772A375B7*)il2cpp_codegen_object_new(AreaTargetCapture_tF1573FE5455CB577983E0EC51649A86772A375B7_il2cpp_TypeInfo_var);
		NullCheck(L_3);
		AreaTargetCapture__ctor_m5726D7F66BC66BD54981C64490A21EB8D7026B17(L_3, L_0, L_1, L_2, NULL);
		return L_3;
	}
}
// System.Void Vuforia.Internal.AreaTargetCapture.AreaTargetCaptureFactory::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void AreaTargetCaptureFactory__ctor_mEB27317E94DEF47C94A06B09F3CE38BF3AB77437 (AreaTargetCaptureFactory_t58049FE46C467D9CBA2250BC360771647AF7C102* __this, const RuntimeMethod* method) 
{
	{
		Object__ctor_mE837C6B9FA8C6D5D109F4B2EC885D79919AC0EA2(__this, NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.UInt32 <PrivateImplementationDetails>::ComputeStringHash(System.String)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR uint32_t U3CPrivateImplementationDetailsU3E_ComputeStringHash_mB7159BE518FEA0D73F5BC9B9A1D847719F171655 (String_t* ___s0, const RuntimeMethod* method) 
{
	uint32_t V_0 = 0;
	int32_t V_1 = 0;
	{
		String_t* L_0 = ___s0;
		if (!L_0)
		{
			goto IL_002a;
		}
	}
	{
		V_0 = ((int32_t)-2128831035);
		V_1 = 0;
		goto IL_0021;
	}

IL_000d:
	{
		String_t* L_1 = ___s0;
		int32_t L_2 = V_1;
		NullCheck(L_1);
		Il2CppChar L_3;
		L_3 = String_get_Chars_mC49DF0CD2D3BE7BE97B3AD9C995BE3094F8E36D3(L_1, L_2, NULL);
		uint32_t L_4 = V_0;
		V_0 = ((int32_t)il2cpp_codegen_multiply(((int32_t)((int32_t)L_3^(int32_t)L_4)), ((int32_t)16777619)));
		int32_t L_5 = V_1;
		V_1 = ((int32_t)il2cpp_codegen_add(L_5, 1));
	}

IL_0021:
	{
		int32_t L_6 = V_1;
		String_t* L_7 = ___s0;
		NullCheck(L_7);
		int32_t L_8;
		L_8 = String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline(L_7, NULL);
		if ((((int32_t)L_6) < ((int32_t)L_8)))
		{
			goto IL_000d;
		}
	}

IL_002a:
	{
		uint32_t L_9 = V_0;
		return L_9;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_MANAGED_FORCE_INLINE IL2CPP_METHOD_ATTR int32_t String_get_Length_m42625D67623FA5CC7A44D47425CE86FB946542D2_inline (String_t* __this, const RuntimeMethod* method) 
{
	{
		int32_t L_0 = __this->____stringLength_4;
		return L_0;
	}
}
