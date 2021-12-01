using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySolution.Module.BusinessObjects;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web;


namespace MySolution.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class WebDateEditCalendarController : ObjectViewController<DetailView, Contact>
    {
        
        public WebDateEditCalendarController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            View.CustomizeViewItemControl(this, SetCalendarView, nameof(Contact.Birthday));
            // Perform various tasks depending on the target View.
        }

        private void SetCalendarView(ViewItem viewItem)
        {
            var propertyEditor = viewItem as ASPxDateTimePropertyEditor;

            if (propertyEditor != null && propertyEditor.ViewEditMode == ViewEditMode.Edit)
            {
                ASPxDateEdit dateEdit = propertyEditor.Editor;
                dateEdit.PickerDisplayMode = DatePickerDisplayMode.ScrollPicker;
            }
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
