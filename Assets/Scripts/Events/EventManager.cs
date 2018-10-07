using System.Collections.Generic;
//using XLua;

//[CSharpCallLua]
public delegate void EventHandlerDelegate(object param);
//[CSharpCallLua]
//public delegate void LuaEventHandlerDelegate(LuaTable self, object param);

//[LuaCallCSharp, XLua.Hotfix]
public class EventManager
{
	private static Dictionary<string, EventManager> _managers = new Dictionary<string, EventManager>();
	private static EventManager _defaultManager;
	private const string DEFAULT = "Default";

    private Dictionary<string, EventHandlerDelegate> _listerners = new Dictionary<string, EventHandlerDelegate>();
    //private Dictionary<string, LuaEventHandlerDelegate> lua_listerners = new Dictionary<string, LuaEventHandlerDelegate>();
    //private Dictionary<LuaEventHandlerDelegate, LuaTable> lua_selfs = new Dictionary<LuaEventHandlerDelegate, LuaTable>();
	private Dictionary<EventHandlerDelegate, int> _handlers = new Dictionary<EventHandlerDelegate, int>();
	static EventManager()
	{
		_managers.Add(DEFAULT, new EventManager());
	}

	private EventManager()
	{
        
	}

	public static EventManager Instance
	{
		get
		{
			if (_defaultManager == null) {
				_defaultManager = Get();
			}
			return _defaultManager;
		}
	}

	/// 获取新的事件管理器
	public static EventManager Get(string name = null)
	{
		if(name == null || name == DEFAULT){
			return _managers[DEFAULT];
		}else{
			if(_managers.ContainsKey(name)){
				return _managers[name];
			}else{
				EventManager manager = new EventManager();
				_managers.Add(name, manager);
				return manager;
			}
		}
	}

    /// 添加监听事件
    public void AddEventListener(string type, EventHandlerDelegate listener)
    {
		if (string.IsNullOrEmpty(type)) {
			return;
		}
		if(HasEventListener(listener)){
			UnityEngine.Debug.LogError("CSEvent重复侦听");
			return;
		}
        if (!_listerners.ContainsKey(type))
        {
            EventHandlerDelegate deleg = null;
            _listerners[type] = deleg;
        }
		_handlers.Add(listener,1);
        _listerners[type] += listener;
    }

	

    /// 移除监听事件
    public void RemoveEventListener(string type, EventHandlerDelegate listener)
    {
		if (string.IsNullOrEmpty(type)) {
			return;
		}
        if (_listerners.ContainsKey(type))
        {
			_listerners[type] -= listener;
			if(_listerners[type] == null)
			{
				_listerners.Remove(type);
			}
        }
		if(_handlers.ContainsKey(listener)){
			_handlers.Remove(listener);
		}
    }

    #region Lua Event
    /*
    public void AddEventListener(string type, LuaTable self, LuaEventHandlerDelegate listener)
    {
        if (string.IsNullOrEmpty(type))
        {
            return;
        }
        if (lua_selfs.ContainsKey(listener))
        {
            UnityEngine.Debug.LogError("重复侦听" + self.Get<string>("name"));
            return;
        }
        if (!lua_listerners.ContainsKey(type))
        {
            LuaEventHandlerDelegate deleg = null;
            lua_listerners[type] = deleg;
        }
        lua_selfs.Add(listener, self);
        lua_listerners[type] += listener;
    }

    public void RemoveEventListener(string type, LuaTable self, LuaEventHandlerDelegate listener)
    {
        if (string.IsNullOrEmpty(type))
        {
            return;
        }
        if (lua_listerners.ContainsKey(type))
        {
            lua_listerners[type] -= listener;
            if (lua_listerners[type] == null)
            {
                lua_listerners.Remove(type);
            }
        }
        if (lua_selfs.ContainsKey(listener))
        {
            lua_selfs.Remove(listener);
        }
    }
    */
    #endregion


    /// 派发数据
    public void DispatchEvent(string type, object param = null)
    {
		if (string.IsNullOrEmpty(type)) {
			return;
		}
		if (_listerners.ContainsKey(type))
        {
			_listerners[type](param);
        }
        /*if (lua_listerners.ContainsKey(type))
        {
			var delegates = lua_listerners[type].GetInvocationList();
			for (int i = delegates.Length - 1; i >= 0 ; i--)
			{
				var _delegate = delegates[i] as LuaEventHandlerDelegate;
				if (lua_selfs.ContainsKey(_delegate)) {
					_delegate(lua_selfs[_delegate], param);
				}
			}
        }*/
    }

    /// 查找是否有当前类型事件监听
    public bool HasEventListener(string type)
    {
		if (string.IsNullOrEmpty(type)) {
			return false;
		}
        return _listerners.ContainsKey(type);
    }

	public bool HasEventListener(EventHandlerDelegate listener)
	{
		return _handlers.ContainsKey(listener);
	}

	public void Destory()
	{
		_listerners.Clear();
		//lua_listerners.Clear();
		//lua_selfs.Clear();
		/* _listerners = null;
		lua_listerners = null;
		lua_selfs = null; */
	}
}