using System;
using NUnit.Framework;
using Silanis.ESL.SDK;

namespace SDK.Examples
{
    [TestFixture()]
    public class TemplateExampleTest
    {
        [Test()]
        public void VerifyResult()
        {
            TemplateExample example = new TemplateExample( Props.GetInstance() );
            example.Run();

            DocumentPackage template = example.EslClient.GetPackage(example.templateId);

            Assert.AreEqual(example.UPDATED_TEMPLATE_NAME, template.Name);
            Assert.AreEqual(example.UPDATED_TEMPLATE_DESCRIPTION, template.Description);

            DocumentPackage documentPackage = example.EslClient.GetPackage(example.instantiatedTemplateId);

            Assert.AreEqual(example.PACKAGE_NAME, documentPackage.Name);

            Assert.AreEqual(example.SIGNER1_FIRST_NAME, documentPackage.Signers[1].FirstName);
            Assert.AreEqual(example.SIGNER1_LAST_NAME, documentPackage.Signers[1].LastName);
            Assert.AreEqual(example.SIGNER1_TITLE, documentPackage.Signers[1].Title);
            Assert.AreEqual(example.SIGNER1_COMPANY, documentPackage.Signers[1].Company);

            Assert.AreEqual(example.SIGNER2_FIRST_NAME, documentPackage.Signers[2].FirstName);
            Assert.AreEqual(example.SIGNER2_LAST_NAME, documentPackage.Signers[2].LastName);
            Assert.AreEqual(example.SIGNER2_TITLE, documentPackage.Signers[2].Title);
            Assert.AreEqual(example.SIGNER2_COMPANY, documentPackage.Signers[2].Company);
        }
    }
}

