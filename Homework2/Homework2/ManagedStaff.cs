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
    
    public void ShowStaff()
    {
        int index = 1;
        
        if (_staff.Count == 0)
            Console.WriteLine("Staff not added yet");
        
        foreach (var staff in _staff)
        {
            Console.WriteLine($"{index} - Name: {staff.Name}, Post: {staff.Post}");
            index++;
        }
    }

    public List<Staff> GetStaff()
    {
        return _staff;
    }
}