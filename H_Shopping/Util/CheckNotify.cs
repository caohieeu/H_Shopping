namespace H_Shopping.Util
{
    public static class CheckNotify
    {
        public static bool CheckSuccess(object status)
        {
            if(status != null && status?.ToString() == "Success")
            {
                return true;
            }
            return false;
        }

        public static bool CheckError(object status)
        {
            if (status != null && status?.ToString() == "Failed")
            {
                return true;
            }
            return false;
        }
    }
}
