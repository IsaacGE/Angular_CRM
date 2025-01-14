# NOTES

### Scaffold command 
```
	Scaffold-DbContext "Server=PC-Mago;Database=AngularCRM;Trusted_Connection=true;Min Pool Size=1;MultipleActiveResultSets=true;TrustServerCertificate=True;Encrypt=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Context AppDbContext -ContextDir DbContext -DataAnnotations -Force
```