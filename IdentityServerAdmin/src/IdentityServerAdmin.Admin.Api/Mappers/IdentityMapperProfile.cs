﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using AutoMapper;

using IdentityServerAdmin.Admin.Api.Dtos.Roles;
using IdentityServerAdmin.Admin.Api.Dtos.Users;

using Skoruba.Duende.IdentityServer.Admin.BusinessLogic.Identity.Dtos.Identity;

namespace IdentityServerAdmin.Admin.Api.Mappers
{
    public class IdentityMapperProfile<TRoleDto, TUserRolesDto, TKey, TUserClaimsDto, TUserClaimDto, TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimDto, TRoleClaimsDto> : Profile
        where TUserClaimsDto : UserClaimsDto<TUserClaimDto, TKey>
        where TUserClaimDto : UserClaimDto<TKey>
        where TRoleDto : RoleDto<TKey>
        where TUserRolesDto : UserRolesDto<TRoleDto, TKey>
        where TUserProviderDto : UserProviderDto<TKey>
        where TUserProvidersDto : UserProvidersDto<TUserProviderDto, TKey>
        where TUserChangePasswordDto : UserChangePasswordDto<TKey>
        where TRoleClaimsDto : RoleClaimsDto<TRoleClaimDto, TKey>
        where TRoleClaimDto : RoleClaimDto<TKey>
    {
        public IdentityMapperProfile()
        {
            // entity to model
            CreateMap<TUserClaimsDto, UserClaimsApiDto<TKey>>(MemberList.Destination);
            CreateMap<TUserClaimsDto, UserClaimApiDto<TKey>>(MemberList.Destination);

            CreateMap<UserClaimApiDto<TKey>, TUserClaimsDto>(MemberList.Source);
            CreateMap<TUserClaimDto, UserClaimApiDto<TKey>>(MemberList.Destination);

            CreateMap<TUserRolesDto, UserRolesApiDto<TRoleDto>>(MemberList.Destination);
            CreateMap<UserRoleApiDto<TKey>, TUserRolesDto>(MemberList.Destination);

            CreateMap<TUserProviderDto, UserProviderApiDto<TKey>>(MemberList.Destination);
            CreateMap<TUserProvidersDto, UserProvidersApiDto<TKey>>(MemberList.Destination);
            CreateMap<UserProviderDeleteApiDto<TKey>, TUserProviderDto>(MemberList.Source);

            CreateMap<UserChangePasswordApiDto<TKey>, TUserChangePasswordDto>(MemberList.Destination);

            CreateMap<RoleClaimsApiDto<TKey>, TRoleClaimsDto>(MemberList.Source);
            CreateMap<RoleClaimApiDto<TKey>, TRoleClaimDto>(MemberList.Destination);
            CreateMap<RoleClaimApiDto<TKey>, TRoleClaimsDto>(MemberList.Destination);

            CreateMap<TRoleClaimsDto, RoleClaimsApiDto<TKey>>(MemberList.Source);
            CreateMap<TRoleClaimDto, RoleClaimApiDto<TKey>>(MemberList.Destination);
            CreateMap<TRoleClaimsDto, RoleClaimApiDto<TKey>>(MemberList.Destination);
        }
    }
}







