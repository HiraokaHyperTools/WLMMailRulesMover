using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace WLMMailRulesMover {
    public class UtPriv {
        public static String SE_RESTORE_NAME { get { return "SeRestorePrivilege"; } }

        // C:\Proj\gc-kumpro\trunk\REGHive\A.cpp
        public static void EnablePriv(String pszName) {
            IntPtr hToken;
            if (OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out hToken)) {
                try {
                    TOKEN_PRIVILEGES state = new TOKEN_PRIVILEGES();
                    state.PrivilegeCount = 1;
                    state.Privileges = new LUID_AND_ATTRIBUTES[1];
                    state.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
                    if (LookupPrivilegeValue(null, pszName, out state.Privileges[0].Luid)) {
                        if (AdjustTokenPrivileges(hToken, false, ref state, 0, IntPtr.Zero, IntPtr.Zero)) {
                            return;
                        }
                        else throw new Win32Exception();
                    }
                    else throw new Win32Exception();
                }
                finally {
                    CloseHandle(hToken);
                }
            }
            else throw new Win32Exception();
        }

        // Use this signature if you want the previous state information returned
        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AdjustTokenPrivileges(IntPtr TokenHandle,
           [MarshalAs(UnmanagedType.Bool)]bool DisableAllPrivileges,
           ref TOKEN_PRIVILEGES NewState,
           UInt32 BufferLengthInBytes,
           IntPtr PreviousState,
           IntPtr ReturnLengthInBytes);

        [StructLayout(LayoutKind.Sequential)]
        struct LUID {
            public uint LowPart;
            public int HighPart;
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool LookupPrivilegeValue(string lpSystemName, string lpName,
            out LUID lpLuid);

        const UInt32 SE_PRIVILEGE_ENABLED = 0x00000002;

        [StructLayout(LayoutKind.Sequential)]
        struct LUID_AND_ATTRIBUTES {
            public LUID Luid;
            public UInt32 Attributes;
        }

        struct TOKEN_PRIVILEGES {
            public UInt32 PrivilegeCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public LUID_AND_ATTRIBUTES[] Privileges;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        //Use these for DesiredAccess
        const UInt32 TOKEN_QUERY = 0x0008;
        const UInt32 TOKEN_ADJUST_PRIVILEGES = 0x0020;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool OpenProcessToken(IntPtr ProcessHandle,
            UInt32 DesiredAccess, out IntPtr TokenHandle);
    }
}
