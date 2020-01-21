using System.Security.AccessControl;
using System.Security.Principal;

namespace eWayCRM.API.Threading
{
    /// <summary>
    /// Class for Mutex management.
    /// </summary>
    public static class Mutex
    {
        /// <summary>
        /// Gets instance of the named Mutex.
        /// </summary>
        /// <param name="name">Name of the mutex.</param>
        /// <returns></returns>
        public static System.Threading.Mutex GetNamedMutex(string name)
        {
            System.Threading.Mutex mutex = null;
            bool exist = true;

            try
            {
                mutex = System.Threading.Mutex.OpenExisting(name);
            }
            catch (System.Threading.WaitHandleCannotBeOpenedException)
            {
                exist = false;
            }
            
            if (!exist)
            {
                SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                MutexSecurity mutexSecurity = new MutexSecurity();
                MutexAccessRule accessRule = new MutexAccessRule(sid, MutexRights.FullControl, AccessControlType.Allow);

                mutexSecurity.AddAccessRule(accessRule);

                mutex = new System.Threading.Mutex(false, name, out _, mutexSecurity);
            }

            return mutex;
        }
    }
}
