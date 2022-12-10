namespace hvc.Extensions;

public class OneTimeFlag
{
    private Boolean _flag = true;

    public Boolean IsFirstTime()
    {
        if (!_flag) 
            return false;
        
        _flag = false;
        return true;
    }

    public void RaiseFlag()
    {
        _flag = true;
    }
}
