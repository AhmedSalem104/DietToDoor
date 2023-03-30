using DataMapping.Entites;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;

namespace ERPWeb.Models.SecurityRoles
{
    public class LoggedUser
    {
        static ApplicationDbContext db = new ApplicationDbContext();

        public static bool InRole(string FunctionId, string Option)
        {
            bool result = false;
            int? EmployeeId = HelperMethods.globalData.EmployeeId; //Will check the national id of the logged user

            var user = db.Employee.Where(x => x.Id == EmployeeId).FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            int GroubId = 0;
            int SystemFunctionId = db.SystemFunction.Where(s => s.Controller == FunctionId).FirstOrDefault().Id;
            var GroubExist = db.EmployeeGroups.Where(g => g.EmployeeId == EmployeeId).FirstOrDefault();
            if (GroubExist != null)
            {
                GroubId = GroubExist.GroupId;
            }
            var UserSecurityRole = db.EmployeeSecurityRoles.FirstOrDefault(role => role.SystemFunctionId == SystemFunctionId && role.EmployeeId == user.Id);
            var GropupSecurityRole = db.GroupSecurityRole.FirstOrDefault(role => role.SystemFunctionId == SystemFunctionId && role.GroupId == GroubId);
            if (UserSecurityRole == null && GropupSecurityRole == null)
            {
                return false;
            }
            switch (Option)
            {
                case "view":
                    {
                        if (UserSecurityRole != null) { result = UserSecurityRole.CanView; }
                        if (GropupSecurityRole != null) { result = GropupSecurityRole.CanView; }
                        break;
                    }
                case "create":
                    {
                        if (UserSecurityRole != null) { result = UserSecurityRole.CanAdd; }
                        if (GropupSecurityRole != null) { result = GropupSecurityRole.CanAdd; }
                        break;
                    }
                case "edit":
                    {
                        if (UserSecurityRole != null) { result = UserSecurityRole.CanEdit; }
                        if (GropupSecurityRole != null) { result = GropupSecurityRole.CanEdit; }
                        break;
                    }
                case "delete":
                    {
                        if (UserSecurityRole != null) { result = UserSecurityRole.CanDelete; }
                        if (GropupSecurityRole != null) { result = GropupSecurityRole.CanDelete; }
                        break;
                    }
                default:
                    {
                        result = false;
                        break;
                    }
            }
            return result;
        }

        public static List<MenuItem> GetMenuItems(int? EmployeeId)
        {
            int GroupId = 0;
            var GroubExist = db.EmployeeGroups.Where(g => g.EmployeeId == EmployeeId).FirstOrDefault();

            if (GroubExist != null)
            {
                GroupId = GroubExist.GroupId;
            }

            var GroupSecurityRoles = db.SystemFunction.Where(x =>(x.SystemFunctionParentsId!=2014 )&& x.GroupSecurityRoles.Any(z => z.GroupId == GroupId
            && z.CanView == true )).GroupBy(x => x.SystemFunctionParents).ToList();

            var EmployeeecurityRoles = db.SystemFunction.Where(x => (x.SystemFunctionParentsId != 2014 && x.Id != 5071) && x.EmployeeSecurityRoles.Any(z => z.EmployeeId == EmployeeId
            && z.CanView == true)).GroupBy(x => x.SystemFunctionParents).ToList();

            var MenuItems = new List<MenuItem>();
            MenuItem newMenuItem = new MenuItem();
            if (GroupSecurityRoles.Count > 0)
            {
                foreach (var item in GroupSecurityRoles)
                {
                    newMenuItem = new MenuItem();
                    newMenuItem.Id = item.Key.Id;
                    newMenuItem.NameInArabic = item.Key.NameInArabic;
                    newMenuItem.NameInEnglish = item.Key.NameInEnglish;
                    newMenuItem.Icons = item.Key.Icons;
                    newMenuItem.MainMenuId = item.Key.MainMenuId;
                    if (item.Key.HasParent == false)
                    {
                        newMenuItem.SystemFunctions = item.Select(function => new SystemFunction()
                        {
                            NameInArabic = function.NameInArabic,
                            NameInEnglish = function.NameInEnglish,
                            Controller = function.Controller,
                            Action = function.Action,
                            Icon = function.Icon,
                            AddAction =function.AddAction,
                        }).ToList();

                        MenuItems.Add(newMenuItem);
                    }
                    else
                    {
                        if (MenuItems.Any(x => x.NameInArabic == item.Key.NameInArabic))
                        {
                            MenuItems.FirstOrDefault(x => x.NameInArabic == item.Key.NameInArabic).MenuItems.Add(new MenuItem()
                            {
                                NameInArabic = item.Key.SecondLevelInArabic,
                                NameInEnglish = item.Key.SecondLevelInEnglish,
                                Icons = item.Key.Icons,
                                SystemFunctions = item.Select(function => new SystemFunction()
                                {
                                    NameInArabic = function.NameInArabic,
                                    NameInEnglish = function.NameInEnglish,
                                    Controller = function.Controller,
                                    Action = function.Action,
                                    Icon = function.Icon,
                                    AddAction= function.AddAction
                                }).ToList()
                            });
                        }
                        else
                        {
                            newMenuItem.MenuItems.Add(new MenuItem()
                            {
                                Id = item.Key.Id,
                                NameInArabic = item.Key.SecondLevelInArabic,
                                NameInEnglish = item.Key.SecondLevelInEnglish,
                                Icons = item.Key.Icons,
                                SystemFunctions = item.Select(function => new SystemFunction()
                                {
                                    NameInArabic = function.NameInArabic,
                                    NameInEnglish = function.NameInEnglish,
                                    Controller = function.Controller,
                                    Action = function.Action,
                                    Icon = function.Icon,
                                    AddAction = function.AddAction
                                }).ToList()
                            });

                            MenuItems.Add(newMenuItem);
                        }
                    }
                }
            }
            else
            {
                foreach (var item in EmployeeecurityRoles)
                {
                    newMenuItem = new MenuItem();
                    newMenuItem.Id = item.Key.Id;
                    newMenuItem.NameInArabic = item.Key.NameInArabic;
                    newMenuItem.NameInEnglish = item.Key.NameInEnglish;
                    newMenuItem.Icons = item.Key.Icons;
                    if (item.Key.HasParent == false)
                    {
                        newMenuItem.SystemFunctions = item.Select(function => new SystemFunction()
                        {
                            NameInArabic = function.NameInArabic,
                            NameInEnglish = function.NameInEnglish,
                            Controller = function.Controller,
                            Action = function.Action,
                            Icon = function.Icon

                        }).ToList();

                        MenuItems.Add(newMenuItem);
                    }
                    else
                    {
                        if (MenuItems.Any(x => x.NameInArabic == item.Key.NameInArabic))
                        {
                            MenuItems.FirstOrDefault(x => x.NameInArabic == item.Key.NameInArabic).MenuItems.Add(new MenuItem()
                            {
                                NameInArabic = item.Key.SecondLevelInArabic,
                                NameInEnglish = item.Key.SecondLevelInEnglish,
                                Icons = item.Key.Icons,
                                SystemFunctions = item.Select(function => new SystemFunction()
                                {
                                    NameInArabic = function.NameInArabic,
                                    NameInEnglish = function.NameInEnglish,
                                    Controller = function.Controller,
                                    Action = function.Action,
                                    Icon = function.Icon
                                }).ToList()
                            });
                        }
                        else
                        {
                            newMenuItem.MenuItems.Add(new MenuItem()
                            {
                                Id = item.Key.Id,
                                NameInArabic = item.Key.SecondLevelInArabic,
                                NameInEnglish = item.Key.SecondLevelInEnglish,
                                Icons = item.Key.Icons,
                                AddAction = item.Key.NameInArabic,
                                SystemFunctions = item.Select(function => new SystemFunction()
                                {
                                    NameInArabic = function.NameInArabic,
                                    NameInEnglish = function.NameInEnglish,
                                    Controller = function.Controller,
                                    Action = function.Action,
                                    Icon = function.Icon
                                }).ToList()
                            });

                            MenuItems.Add(newMenuItem);
                        }
                    }
                }

            }

            return MenuItems;
        }

        //internal static void CreateActionLog(int v1, object userID, int v2, int v3, string v4)
        //{
        //    throw new NotImplementedException();
        //}

        public class MenuItem
        {
            public MenuItem()
            {
                MenuItems = new List<MenuItem>();
                SystemFunctions = new List<SystemFunction>();
            }
            public int Id { get; set; }
            public string NameInArabic { get; set; }
            public string NameInEnglish { get; set; }
            public string Icons { get; set; }
            public string AddAction { get; set; }

            public int? MainMenuId { get; set; }
            public List<MenuItem> MenuItems { get; set; }
            public List<SystemFunction> SystemFunctions { get; set; }
        }

        public static void CreateActionLog(int? FunId,int? UserId , int? ActionId , int? RecordId , string functionName)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            ActionLog actionLog = new ActionLog
            {
                ActionId = ActionId,
                RecordId = RecordId,
                SystemFunctionId = FunId,
                IP = ip,
                CreatedDate =DateTime.Now,
                UsersId = UserId,
                FunctionName = functionName

            };
            db.ActionLog.Add(actionLog);
            db.SaveChanges();
        }
    }
}