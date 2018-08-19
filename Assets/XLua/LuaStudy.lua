function max(a,b)
	if(a>b)
	then
		result=a
	else
		result=b
	end
	return result
end

print(max(10,15))

myprint=function(param)
	print("ÀàËÆÎ¯ÍĞÕâÀàµÄÂğ",param)
end

print("----------------ÍêÃÀ·Ö¸îÏß-----------")

print("luaÖĞ¿ÉÒÔ½«º¯Êı×÷Îª²ÎÊı´«µİ¸øº¯Êı ")

function add(a,b,delegate)
	result=a+b
	delegate(result)
end

add(3,4,myprint)

print("Ñ°ÕÒÊı×éÖĞ×î´óÖµ·µ»Ø¶à²ÎÊı")
function maximum(a)
	local mi=1
	local m=a[mi]
	for i,val in ipairs(a) do
		if val >m then
			mi=i
			m=val
		end
	end
	return m,mi
end

print(maximum({35,5,10,25}))

print("¿É±ä²ÎÊı")
print("----------------ÍêÃÀ·Ö¸îÏß-----------")

function average(...)
	result=0
	local arg={...}
	for i,val in ipairs(arg) do
		result=result+val
	end
	print("all send: "..#arg .. " list count")
	return result/#arg
end

print("num average:",average(23,32,4,4,6,7))

print("----------------ÍêÃÀ·Ö¸îÏß-----------")
print("----------------¹ØÓÚ__indexÔª·½·¨-----------")

--ÕâÊÇ metatable ×î³£ÓÃµÄ¼ü
--ÄãÍ¨¹ı¼üÀ´·ÃÎÊ table µÄÊ±ºò£¬Èç¹ûÕâ¸ö¼üÃ»ÓĞÖµ£¬ÄÇÃ´Lua¾Í»áÑ°ÕÒ¸ÃtableµÄmetatable£¨¼Ù¶¨ÓĞmetatable£©ÖĞµÄ__index ¼ü¡
--Èç¹û__index°üº¬Ò»¸ö±í¸ñ£¬Lua»áÔÚ±í¸ñÖĞ²éÕÒÏàÓ¦µÄ¼ü¡£

--Èç¹û__index°üº¬Ò»¸öº¯ÊıµÄ»°£¬Lua¾Í»áµ÷ÓÃÄÇ¸öº¯Êı£¬tableºÍ¼ü»á×÷Îª²ÎÊı´«µİ¸øº¯Êı
--__index Ôª·½·¨²é¿´±íÖĞÔªËØÊÇ·ñ´æÔÚ£¬Èç¹û²»´æÔÚ£¬·µ»Ø½á¹ûÎª nil£»Èç¹û´æÔÚÔòÓÉ __index ·µ»Ø½á¹û

mytable=setmetatable({key1="value1"},
	{
		__index=function(mytable,key)
			if key=="key2" then
				return "metatablevalue"
			else
				return nil
			end
		end

	}
)
print(mytable)
print(mytable.key1,mytable.key2,mytable.key)
