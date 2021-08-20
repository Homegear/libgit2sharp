using LibGit2Sharp.Core;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LibGit2Sharp.Ssh
{

    internal static class NativeMethodsAgent
    {
        private const string libgit2 = NativeDllName.Name;

        [DllImport(libgit2)]
        internal static extern int git_credential_ssh_key_from_agent(
             out IntPtr cred,
             [MarshalAs(UnmanagedType.CustomMarshaler, MarshalCookie = UniqueId.UniqueIdentifier, MarshalTypeRef = typeof(StrictUtf8Marshaler))] string username);

    }

    /// <summary>
    /// Class that holds SSH username and gets credentials from agent for remote repository access.
    /// </summary>
    public sealed class SshAgentCredentials : Credentials
    {
        /// <summary>
        /// Callback to acquire a credential object.
        /// </summary>
        /// <param name="cred">The newly created credential object.</param>
        /// <returns>0 for success, &lt; 0 to indicate an error, &gt; 0 to indicate no credential was acquired.</returns>
        internal protected override int GitCredentialHandler(out IntPtr cred)
        {
            if (Username == null)
            {
                throw new InvalidOperationException("SshAgentCredentials contains a null Username.");
            }

            return NativeMethodsAgent.git_credential_ssh_key_from_agent(out cred, Username);
        }

        /// <summary>
        /// Username for SSH authentication.
        /// </summary>
        public string Username { get; set; }

    }
}
