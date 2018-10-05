

--建议的加载Lua脚本方式是：整个程序就一个DoString("require 'main'")，然后在main.lua加载其它脚本（类似lua脚本的命令行执行：lua main.lua

local player=require 'Player'
local camera_lua=require 'camera'
local res_lua=require 'res'
local uiImage_lua=require 'uiimage'
local GameObject = CS.UnityEngine.GameObject

function awake()
	print("call the awake by monobehaviour")
	player.awake()


end

--call by C# MonoBehaviour
function start()
	print("on start")
	logo:GetComponent("Text").text="杀死一只知更鸟"
	setBtn.transform:Find("Text"):GetComponent("Text").text="设置"
	playBtn.transform:Find("Text"):GetComponent("Text").text="开始游戏"
	shopbtn.transform:Find("Text"):GetComponent("Text").text="商店"
	shopbtn:GetComponent("Button").onClick:AddListener(click_handle)
	playBtn:GetComponent("Button").onClick:AddListener(play_handle)
end

function play_handle()
	print("start game")
	gamepanel:SetActive(true)
end

function click_handle()
	print("option click handle")
end

--call by C# MonoBehaviour
function update()
end

--call by C# MonoBehaviour
function ondestroy()
	print("on destroy")
end
