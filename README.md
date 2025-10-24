# Quản lí cửa hàng cà phê CF36
## ✨ Tính năng chính 

- 🛒 Bán hàng trực tiếp tại quầy (POS).

- 📦 Quản lý sản phẩm trong kho.

- 📋 Quản lý khách hàng & lịch sử giao dịch

- 📊 Thống kê, báo cáo phục vụ quản lý.

- 🔐 Phân quyền sử dụng (Admin & Nhân viên)

## 🚀Yêu cầu hệ thống
- Windows 10/11 (64-bit)

- NET 6.0 Runtime

- SQL Server 2019+ (hoặc LocalDB)

- Visual Studio 2022 (để phát triển)

- Ứng dụng Windows Forms được xây dựng bằng .NET, theo cấu trúc best practice với các thư mục `src/`, `tests/`, `docs/`.

## 🔧Cách chạy
1. git clone từ repo trên github
git clone https://github.com/HoangLongg17/CAFEE.git
cd CF36
2. Mở file `.sln` bằng Visual Studio
3. Tải DataBase [Download Tại Đây](https://drive.google.com/file/d/1AQMyLSNrDUfl9LguolSDBEtS5-t5Nn9I/view?usp=sharing)
4. Cấu hình kết nối trong file: `.App.config`
   
- `<connectionStrings>
	<add name="QUANLICAFE36"
		 connectionString="Data Source=.\SQLEXPRESS01;Initial Catalog=QLCF;Integrated Security=True;TrustServerCertificate=True;"
		 providerName="System.Data.SqlClient" />
</connectionStrings>`

5.Chạy ứng dụng
- Nhấn F5 để chạy Debug
- Hoặc Ctrl + F5 để chạy không Debug
## 🎉 Chúc mừng!
Bạn đã chạy và chỉnh sửa thành công ứng dụng WinForms Quản lý Cafe. 🥳
## ⚠️ Lưu ý quan trọng
- Kiểm tra SQL Server Instance: Đảm bảo SQLEXPRESS01 đang chạy

 - Database tồn tại: Database QLCF phải được tạo trước

- Quyền truy cập: Tài khoản Windows có quyền truy cập database
## Cấu trúc
- `src/`: mã nguồn chính
- `tests/`: kiểm thử
- `docs/`: tài liệu kỹ thuật
## 🐛 Khắc phục sự cố
### Kiểm tra kết nối database
`sql
-- Kiểm tra database tồn tại
SELECT name FROM sys.databases WHERE name = 'QLCF'`;
### Lỗi thường gặp
- "Cannot open database": Kiểm tra tên database

- "Login failed": Kiểm tra Windows Authentication

- "Instance not found": Đảm bảo SQL Server đang chạy

## 📞 Hỗ trợ
### Nếu gặp vấn đề trong quá trình cài đặt

- Kiểm tra file README trong thư mục `docs/`

- Mở issue trên` GitHub repository`
