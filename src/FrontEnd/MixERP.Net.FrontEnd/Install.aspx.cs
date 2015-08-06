﻿/********************************************************************************
Copyright (C) MixERP Inc. (http://mixof.org).

This file is part of MixERP.

MixERP is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, version 2 of the License.


MixERP is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with MixERP.  If not, see <http://www.gnu.org/licenses/>.
***********************************************************************************/

using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common;
using MixERP.Net.Common.Helpers;
using MixERP.Net.FrontEnd.Data.Office;
using MixERP.Net.i18n.Resources;
using System;
using System.Linq;
using System.Web.UI.HtmlControls;
using MixERP.Net.i18n;

namespace MixERP.Net.FrontEnd
{
    public partial class Install : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            using (HtmlLink stylesheet = new HtmlLink())
            {
                string path = "/bundles/stylesheets/master-page.min.css";

                if (CurrentCulture.IsRtl())
                {
                    path = path.Replace("min.css", "rtl.min.css");
                }

                stylesheet.Href = path;
                stylesheet.Attributes["rel"] = "stylesheet";
                stylesheet.Attributes["type"] = "text/css";
                stylesheet.Attributes["media"] = "all";
                this.Page.Header.Controls.Add(stylesheet);
            }

            if (Offices.GetOffices(AppUsers.GetCurrentUserDB()).Any())
            {
                this.Response.Redirect("~/SignIn.aspx");
            }

            this.RegisterJavascript();
        }

        private void RegisterJavascript()
        {
            string script = JSUtility.GetVar("allFieldsRequiredLocalized", Labels.AllFieldsRequired);
            script += JSUtility.GetVar("confirmedPasswordDoesNotMatch", Labels.ConfirmedPasswordDoesNotMatch);

            PageUtility.RegisterJavascript("InstallPage_Vars", script, this.Page, true);
        }
    }
}