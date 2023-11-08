﻿using System;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace SPF.Classes
{
    public class Impersonator : IDisposable
    {
            public Impersonator(
                string userName,
                string domainName,
                string password)
            {
                ImpersonateValidUser(userName, domainName, password);
            }

            public void Dispose()
            {
                UndoImpersonation();
            }

            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern int LogonUser(
                string lpszUserName,
                string lpszDomain,
                string lpszPassword,
                int dwLogonType,
                int dwLogonProvider,
                ref IntPtr phToken);

            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern int DuplicateToken(
                IntPtr hToken,
                int impersonationLevel,
                ref IntPtr hNewToken);

            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern bool RevertToSelf();

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            private static extern bool CloseHandle(
                IntPtr handle);

            enum LogonType
            {
                Interactive = 2,
                Network = 3,
                Batch = 4,
                Service = 5,
                Unlock = 7,
                NetworkClearText = 8,
                NewCredentials = 9
            }

            enum LogonProvider
            {
                Default = 0,
                WinNT35 = 1,
                WinNT40 = 2,
                WinNT50 = 3
            }

            private void ImpersonateValidUser(
                string userName,
                string domain,
                string password)
            {
                WindowsIdentity tempWindowsIdentity = null;
                IntPtr token = IntPtr.Zero;
                IntPtr tokenDuplicate = IntPtr.Zero;

                try
                {
                    if (RevertToSelf())
                    {
                        if (LogonUser(
                            userName,
                            domain,
                            password,
                            //LOGON32_LOGON_INTERACTIVE,
                            //LOGON32_PROVIDER_DEFAULT,
                            (int)LogonType.Interactive,
                            (int)LogonProvider.Default,
                            ref token) != 0)
                        {
                            if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                            {
                                tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                                impersonationContext = tempWindowsIdentity.Impersonate();
                            }
                            else
                            {
                                throw new Win32Exception(Marshal.GetLastWin32Error());
                            }
                        }
                        else
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error());
                        }
                    }
                    else
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                }
                finally
                {
                    if (token != IntPtr.Zero)
                    {
                        CloseHandle(token);
                    }
                    if (tokenDuplicate != IntPtr.Zero)
                    {
                        CloseHandle(tokenDuplicate);
                    }
                }
            }

            private void UndoImpersonation()
            {
                if (impersonationContext != null)
                {
                    impersonationContext.Undo();
                }
            }

            private WindowsImpersonationContext impersonationContext = null;
        }
}