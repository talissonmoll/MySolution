using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MySolution.Module.BusinessObjects;

namespace MySolution.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Resume")]
    public class Resume : BaseObject
    {
        public Resume(Session session) : base(session) { }
        private Contact contact;
        public Contact Contact
        {
            get
            {
                return contact;
            }
            set
            {
                SetPropertyValue(nameof(Contact), ref contact, value);
            }
        }

        [DevExpress.Xpo.Aggregated, Association("Resume-PortfolioFileData")]
        public XPCollection<PortfolioFileData> Portfolio
        {
            get { return GetCollection<PortfolioFileData>(nameof(Portfolio)); }
        }
    }

    public class PortfolioFileData : FileAttachmentBase
    {
        public PortfolioFileData(Session session) : base(session) { }
        protected Resume resume;
        [Persistent, Association("Resume-PortfolioFileData")]
        public Resume Resume
        {
            get { return resume; }
            set
            {
                SetPropertyValue(nameof(Resume), ref resume, value);
            }
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            documentType = DocumentType.Unknown;
        }
        private DocumentType documentType;
        public DocumentType DocumentType
        {
            get { return documentType; }
            set { SetPropertyValue(nameof(DocumentType), ref documentType, value); }
        }
    }
    public enum DocumentType
    {
        SourceCode = 1, Tests = 2, Documentation = 3,
        Diagrams = 4, ScreenShots = 5, Unknown = 6
    };
}