﻿using Acme.BookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Acme.BookStore.Permissions;

public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(BookStorePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
        var bookPermission =  bookStoreGroup.AddPermission(BookStorePermissions.Books.Default, L("Permission:Book"));
        bookPermission.AddChild(BookStorePermissions.Books.Create, L("Permission:Books.Create"));
        bookPermission.AddChild(BookStorePermissions.Books.Edit, L("Permission:Books.Edit"));
        bookPermission.AddChild(BookStorePermissions.Books.Delete, L("Permission:Books.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookStoreResource>(name);
    }
}
