Tools > NuGet Package Manager > Package Manager Console
Run Install-Package Microsoft.EntityFrameworkCore.SqlServer
Run Install-Package Microsoft.EntityFrameworkCore.Tools
Run Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design

//
Scaffold-DbContext "Data Source=DESKTOP-NITSS8T;Initial Catalog=Blogging;User ID=sa;Password=12345678;" Microsoft.EntityFrameworkCore.SqlServer -Project Gomo.CC.Model -force -OutputDir ./
Scaffold-DbContext -Connection "Server=(local);Database=Blogging;User ID=sa;Password=12345678;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models  -force

Scaffold-DbContext -Connection "Server=(local);Database=Blogging;User ID=sa;Password=12345678;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir ""  -force
//注意要先卸載所有的專案只剩下model的專案，才能執行下列的專案
Scaffold-DbContext -Connection "Server=(local);Database=Blogging;User ID=sa;Password=12345678;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir "" -Project Gomo.CC.Model  -force 