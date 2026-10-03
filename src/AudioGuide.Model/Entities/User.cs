using AudioGuide.Model.Enums;

namespace AudioGuide.Model.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty; // không lưu mật khẩu thô
    public UserRole Role { get; set; } = UserRole.Visitor;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}