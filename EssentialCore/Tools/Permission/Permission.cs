using EssentialCore.BusinessLogic;
using EssentialCore.Entities;
using EssentialCore.Entities.Core;
using EssentialCore.Tools.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.Tools.Permission
{
    public enum PermissionType
    {
        Add,
        Edit,
        Delete,
        Retrieve
    }

    public static class Permission
    {
        static Permission()
        {
           // ReloadRoleMember();

           // ReloadRolePermission();
        }

        private static List<RolePermission> RolePermissionList { get; set; }

        private static List<RoleMember> RoleMemberList { get; set; }

        public static bool CheckPermission(this IEntityBase entityBase, PermissionType permissionType, UserCredit userCredit)
        {
            return permissionType.CheckPermission(entityBase.Info, userCredit);
        }

        public static bool CheckPermission(this PermissionType permissionType, Info info, UserCredit userCredit)
        {
            if (info == default || info == null)

                return false;

            //foreach (var roleMember in RoleMemberList.Where(rm => rm.Employee_Id == userCredit.Employee_Id).ToList())
            //{
            //    switch (permissionType)
            //    {
            //        case PermissionType.Add:
            //            {
            //                foreach (var rolePermission in RolePermissionList.Where(rp => rp.Role.Id == roleMember.Role.Id && rp.Entity.Schema == info.Schema && rp.Entity.Name == info.Name))
            //                {
            //                    if (rolePermission.AddPermission)

            //                        return true;
            //                }

            //                break;
            //            }
            //        case PermissionType.Edit:
            //            {
            //                foreach (var rolePermission in RolePermissionList.Where(rp => rp.Role.Id == roleMember.Role.Id && rp.Entity.Schema == info.Schema && rp.Entity.Name == info.Name))
            //                {
            //                    if (rolePermission.EditPermission)

            //                        return true;
            //                }

            //                break;
            //            }
            //        case PermissionType.Delete:
            //            {
            //                foreach (var rolePermission in RolePermissionList.Where(rp => rp.Role.Id == roleMember.Role.Id && rp.Entity.Schema == info.Schema && rp.Entity.Name == info.Name))
            //                {
            //                    if (rolePermission.DeletePermission)

            //                        return true;
            //                }

            //                break;
            //            }
            //            //case PermissionType.Retrieve:
            //            //    {
            //            //        foreach (var rolePermission in RolePermissionList.Where(rp => rp.Role.Id == roleMember.Role.Id && rp.Entity.Schema == info.Schema && rp.Entity.Name == info.Name))
            //            //        {
            //            //            if (rolePermission.ViewIndexPermission)

            //            //                return true;
            //            //        }

            //            //        break;
            //            //    }
            //    }
            //}


            return true;
        }

        private static async Task<bool> ReloadRoleMember()
        {
            var service = new Service<RoleMember>();

            var dataResult = await service.RetrieveAll(RoleMember.Informer, 1);

            if (!dataResult.IsSucceeded)

                return false;

            Permission.RoleMemberList = dataResult.Data.ToList();

            return true;
        }

        private static async Task<bool> ReloadRolePermission()
        {
            var service = new Service<RolePermission>();

            var dataResult = await service.RetrieveAll(RolePermission.Informer, 1);

            if (!dataResult.IsSucceeded)

                return false;

            Permission.RolePermissionList = dataResult.Data.ToList();

            return true;
        }
    }
}
