// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers
{
    public partial class FriendController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected FriendController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Accept()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Accept);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult AcceptUser()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AcceptUser);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Add()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Add);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Cancel()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Cancel);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Reject()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Reject);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult RejectUser()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RejectUser);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult Unfriend()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Unfriend);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public System.Web.Mvc.ActionResult UnfriendUser()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UnfriendUser);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public FriendController Actions { get { return MVCT.Friend; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Friend";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Friend";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Accept = "Accept";
            public readonly string AcceptUser = "AcceptUser";
            public readonly string Add = "Add";
            public readonly string Cancel = "Cancel";
            public readonly string Reject = "Reject";
            public readonly string RejectUser = "RejectUser";
            public readonly string RequestCount = "RequestCount";
            public readonly string Requests = "Requests";
            public readonly string Unfriend = "Unfriend";
            public readonly string UnfriendUser = "UnfriendUser";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Accept = "Accept";
            public const string AcceptUser = "AcceptUser";
            public const string Add = "Add";
            public const string Cancel = "Cancel";
            public const string Reject = "Reject";
            public const string RejectUser = "RejectUser";
            public const string RequestCount = "RequestCount";
            public const string Requests = "Requests";
            public const string Unfriend = "Unfriend";
            public const string UnfriendUser = "UnfriendUser";
        }


        static readonly ActionParamsClass_Accept s_params_Accept = new ActionParamsClass_Accept();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Accept AcceptParams { get { return s_params_Accept; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Accept
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_AcceptUser s_params_AcceptUser = new ActionParamsClass_AcceptUser();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AcceptUser AcceptUserParams { get { return s_params_AcceptUser; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AcceptUser
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Add s_params_Add = new ActionParamsClass_Add();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Add AddParams { get { return s_params_Add; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Add
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Cancel s_params_Cancel = new ActionParamsClass_Cancel();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Cancel CancelParams { get { return s_params_Cancel; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Cancel
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Reject s_params_Reject = new ActionParamsClass_Reject();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Reject RejectParams { get { return s_params_Reject; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Reject
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_RejectUser s_params_RejectUser = new ActionParamsClass_RejectUser();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_RejectUser RejectUserParams { get { return s_params_RejectUser; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_RejectUser
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Unfriend s_params_Unfriend = new ActionParamsClass_Unfriend();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Unfriend UnfriendParams { get { return s_params_Unfriend; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Unfriend
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_UnfriendUser s_params_UnfriendUser = new ActionParamsClass_UnfriendUser();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UnfriendUser UnfriendUserParams { get { return s_params_UnfriendUser; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UnfriendUser
        {
            public readonly string id = "id";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _Friend = "_Friend";
                public readonly string _Friends = "_Friends";
                public readonly string _RequestCount = "_RequestCount";
                public readonly string Accept = "Accept";
                public readonly string Add = "Add";
                public readonly string Cancel = "Cancel";
                public readonly string Index = "Index";
                public readonly string Reject = "Reject";
                public readonly string Requests = "Requests";
                public readonly string Unfriend = "Unfriend";
            }
            public readonly string _Friend = "~/Views/Friend/_Friend.cshtml";
            public readonly string _Friends = "~/Views/Friend/_Friends.cshtml";
            public readonly string _RequestCount = "~/Views/Friend/_RequestCount.cshtml";
            public readonly string Accept = "~/Views/Friend/Accept.cshtml";
            public readonly string Add = "~/Views/Friend/Add.cshtml";
            public readonly string Cancel = "~/Views/Friend/Cancel.cshtml";
            public readonly string Index = "~/Views/Friend/Index.cshtml";
            public readonly string Reject = "~/Views/Friend/Reject.cshtml";
            public readonly string Requests = "~/Views/Friend/Requests.cshtml";
            public readonly string Unfriend = "~/Views/Friend/Unfriend.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public class T4MVC_FriendController : Phoenix.PhoenixApp.Presentation.MVC.Client.Controllers.FriendController
    {
        public T4MVC_FriendController() : base(Dummy.Instance) { }

        public override System.Web.Mvc.ActionResult Accept(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Accept);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult AcceptUser(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AcceptUser);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Add(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Add);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Cancel(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Cancel);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Reject(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Reject);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult RejectUser(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RejectUser);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult RequestCount()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RequestCount);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Requests()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Requests);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult Unfriend(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Unfriend);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            return callInfo;
        }

        public override System.Web.Mvc.ActionResult UnfriendUser(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UnfriendUser);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
