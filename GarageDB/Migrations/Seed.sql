--rename Identity* tables AspNet* as framework requires that name
if not exists (select * from sys.tables where name = 'AspNetRoles')
	EXECUTE sp_rename N'dbo.IdentityRoles', N'AspNetRoles', 'OBJECT'

if not exists (select * from sys.tables where name = 'AspNetUserClaims')
	EXECUTE sp_rename N'dbo.IdentityUserClaims', N'AspNetUserClaims', 'OBJECT' 

if not exists (select * from sys.tables where name = 'AspNetUserLogins')
	EXECUTE sp_rename N'dbo.IdentityUserLogins', N'AspNetUserLogins', 'OBJECT' 

if not exists (select * from sys.tables where name = 'AspNetUserRoles')
	EXECUTE sp_rename N'dbo.IdentityUserRoles', N'AspNetUserRoles', 'OBJECT' 