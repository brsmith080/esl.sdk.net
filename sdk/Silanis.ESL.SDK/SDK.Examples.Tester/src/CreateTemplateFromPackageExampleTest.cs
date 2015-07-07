﻿using NUnit.Framework;
using System;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class CreateTemplateFromPackageExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            CreateTemplateFromPackageExample example = new CreateTemplateFromPackageExample(Props.GetInstance());
            example.Run();

            DocumentPackage templatePackage = example.EslClient.GetPackage(example.TemplateId);
            Document document = templatePackage.Documents[example.DOCUMENT_NAME];

            Assert.AreEqual(document.Name, example.DOCUMENT_NAME);
            Assert.AreEqual(document.Id, example.DOCUMENT_ID);

            Assert.AreEqual(templatePackage.Name, example.PACKAGE_NAME_NEW);
            // TODO: Make sure that this is correctly preserved.
            Assert.AreEqual(templatePackage.Signers.Count, 3);
            Assert.AreEqual(templatePackage.Signers[1].FirstName, example.PACKAGE_SIGNER1_FIRST);
            Assert.AreEqual(templatePackage.Signers[1].LastName, example.PACKAGE_SIGNER1_LAST);
            Assert.AreEqual(templatePackage.Signers[2].FirstName, example.PACKAGE_SIGNER2_FIRST);
            Assert.AreEqual(templatePackage.Signers[2].LastName, example.PACKAGE_SIGNER2_LAST);
        }
    }
}

