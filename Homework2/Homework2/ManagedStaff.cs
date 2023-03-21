namespace Homework2;

public class ManagedStaff
{
    private List<Staff> _staff;
    
    public ManagedStaff()
    {
        _staff = new List<Staff>();
    }
    
    public void CreateStaff(Staff staff)
    {
        _staff.Add(staff);
    }

    public void DeleteStaff(int index)
    {
        _staff.RemoveAt(index);
    }

    public List<Staff> GetStaff()
    {
        return _staff;
    }
}