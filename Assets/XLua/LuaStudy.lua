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
	print("����ί���������",param)
end

print("----------------�����ָ���-----------")

print("lua�п��Խ�������Ϊ�������ݸ����� ")

function add(a,b,delegate)
	result=a+b
	delegate(result)
end

add(3,4,myprint)

print("Ѱ�����������ֵ���ض����")
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

print("�ɱ����")
print("----------------�����ָ���-----------")

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

print("----------------�����ָ���-----------")
print("----------------����__indexԪ����-----------")

--���� metatable ��õļ�
--��ͨ���������� table ��ʱ����������û��ֵ����ôLua�ͻ�Ѱ�Ҹ�table��metatable���ٶ���metatable���е�__index ���
--���__index����һ�����Lua���ڱ���в�����Ӧ�ļ���

--���__index����һ�������Ļ���Lua�ͻ�����Ǹ�������table�ͼ�����Ϊ�������ݸ�����
--__index Ԫ�����鿴����Ԫ���Ƿ���ڣ���������ڣ����ؽ��Ϊ nil������������� __index ���ؽ��

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
