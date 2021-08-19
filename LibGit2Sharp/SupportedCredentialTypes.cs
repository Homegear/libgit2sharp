using System;

namespace LibGit2Sharp
{
	/// <summary>
	/// Credential types supported by the server. If the server supports a particular type of
	/// authentication, it will be set to true.
	/// </summary>
	[Flags]
	public enum SupportedCredentialTypes
	{
		/// <summary>
		/// Plain username and password combination
		/// </summary>
		UsernamePassword = (1 << 0),

		/// <summary>
		/// SSH key-based authentication request
		/// </summary>
		SshKey = (1 << 1),

		/// <summary>
		/// SSH key-based authentication request, with a custom signature
		/// </summary>
		SshCustom = (1 << 2), 

		/// <summary>
		/// Ask Windows to provide its default credentials for the current user (e.g. NTLM)
		/// </summary>
		Default = (1 << 3),

		/// <summary>
		/// SSH interactive authentication request
		/// </summary>
		SshInteractive = (1 << 4),

		/// <summary>
		/// Used as a pre-authentication step if the underlying transport
		/// (eg. SSH, with no username in its URL) does not know which username
		/// to use.
		/// </summary>
		Username = (1 << 5),

		/// <summary>
		/// SSH key-based authentication request	    
		/// Allows credentials to be read from memory instead of files.
		/// Note that because of differences in crypto backend support, it might
		/// not be functional.
		/// </summary>
		SshMemory = (1 << 6),
	}
}
