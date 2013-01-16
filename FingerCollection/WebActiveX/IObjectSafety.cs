using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WebActiveX
{
    [Guid("CB5BDC81-93C1-11CF-8F20-00805F2CD064"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IObjectSafety
    {
        /*
        [PreserveSig]
        void GetInterfacceSafyOptions(System.Int32 riid, out System.Int32 pdwSupportedOptions, out System.Int32 pdwEnabledOptions);

        [PreserveSig]
        void SetInterfaceSafetyOptions(System.Int32 riid, System.Int32 dwOptionsSetMask, System.Int32 dwEnabledOptions);
    */
        [PreserveSig]
        int GetInterfaceSafetyOptions(ref Guid riid, [MarshalAs(UnmanagedType.U4)] ref int pdwSupportedOptions, [MarshalAs(UnmanagedType.U4)] ref int pdwEnabledOptions);

        [PreserveSig()]
        int SetInterfaceSafetyOptions(ref Guid riid, [MarshalAs(UnmanagedType.U4)] int dwOptionSetMask, [MarshalAs(UnmanagedType.U4)] int dwEnabledOptions);

     }
}
