namespace footballFantasy.BuisnessLayer;

public class pagination
{
    public static List<T> paging<T>(List<T> list ,int index, int length)
    {
        List<T> page = new List<T>();
        for (int i = 0; i < list.Count; i++)
        {
            if (i / length + 1 == index)
            {
                page.Add(list[i]);
            }
        }
        return page;
    }
}