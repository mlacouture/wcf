// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ServiceModel;
using Xunit;
using Infrastructure.Common;

public static class MessageSecurityOverTcpTest
{
#if FULLXUNIT_NOTSUPPORTED
    [Fact]
#endif
    [WcfFact]
    public static void Ctor_Default_Properties()
    {
        MessageSecurityOverTcp msot = new MessageSecurityOverTcp();
        Assert.True(msot != null, "MessageSecurityOverTcp default ctor failed");
    }

#if FULLXUNIT_NOTSUPPORTED
    [Fact]
#endif
    [WcfFact]
    public static void Ctor_Default_Properties_Not_Supported()
    {
        MessageSecurityOverTcp msot = new MessageSecurityOverTcp();
        Assert.Throws <PlatformNotSupportedException>(() =>
        {
            MessageCredentialType unused = msot.ClientCredentialType;
        });
    }

#if FULLXUNIT_NOTSUPPORTED
    [Theory]
#endif
    [WcfTheory]
    [InlineData(MessageCredentialType.Certificate)]
    [InlineData(MessageCredentialType.IssuedToken)]
    [InlineData(MessageCredentialType.UserName)]
    [InlineData(MessageCredentialType.Windows)]
    public static void ClientCredentialType_Property_Values_Not_Supported(MessageCredentialType credentialType)
    {
        MessageSecurityOverTcp msot = new MessageSecurityOverTcp();
        Assert.Throws<PlatformNotSupportedException>(() =>
        {
            msot.ClientCredentialType = credentialType;
        });
    }

#if FULLXUNIT_NOTSUPPORTED
    [Theory]
#endif
    [WcfTheory]
    [InlineData(MessageCredentialType.None)]
    public static void ClientCredentialType_Property_Values_Supported(MessageCredentialType credentialType)
    {
        MessageSecurityOverTcp msot = new MessageSecurityOverTcp();
        msot.ClientCredentialType = credentialType;
        MessageCredentialType actual = msot.ClientCredentialType;
        Assert.True(actual == credentialType,
                    string.Format("ClientCredentialType returned '{0}' but expected '{1}'", credentialType, actual));
    }
}
