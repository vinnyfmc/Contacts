﻿using System.Web;
using System.Web.Optimization;

namespace Contacts.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.maskedinput.min.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/sweetAlert").Include("~/Scripts/sweetalert2.min.js"));
            bundles.Add(new StyleBundle("~/Content/sweetAlert").Include("~/Content/sweetalert2.min.css"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/NaturalPerson")
                .Include("~/Scripts/Contacts/naturalPerson.js")
                .Include("~/Scripts/Contacts/address.js"));

            bundles.Add(new ScriptBundle("~/bundles/LegalPerson")
                .Include("~/Scripts/Contacts/legalPerson.js")
                .Include("~/Scripts/Contacts/address.js"));
        }
    }
}
