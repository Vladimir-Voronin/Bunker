import requests

def getresponse():
    response = requests.get(url)
    part = response.text
    part = part.replace(r'\nКарта №1',r';\nКарта №1')
    part = part.replace('{"text":"','').replace(r'\n','').replace('"}','')
    partlist = part.split(';')
    partlist = partlist[0:-1]  #Приведение запроса к нужному виду
    return partlist

def main():
    for i in range(1,1000):
        partlist = getresponse()

        for k,v in indexdict.items():
            result = partlist[k].partition(':')[2]
            result = result.strip()
            result = result.capitalize()
            if result not in globals()[v]:
                globals()[v].append(result)
        #print(f'{i}')

    for k,v in indexdict.items():
        with open(f'data\{v}.txt','w') as file:
            for elem in globals()[v]:
                file.write(elem)
                file.write('\n')

    with open(f'data\gender.txt','w') as file:
            for elem in gender:
                file.write(elem)
                file.write('\n')

    with open(f'data\old.txt','w') as file:
            for elem in old:
                file.write(str(elem))
                file.write('\n')

    for k,v in indexdict.items():
        print(len(globals()[v]))
        
url = 'https://randomall.ru/api/custom/gen/758/'

gender = ['Мужской','Женский']
old = [x for x in range(1,90)]
profession = []
childbearing = []
health = []
phobia = []
character = []
hobby = []
additionally = []
baggage = []
card1 = []
card2 = []

indexdict = {2:'profession',
3:'childbearing',
4:'health',
5:'phobia',
6:'hobby',
7:'character',
8:'additionally',
9:'baggage',
10:'card1',
11:'card2'}

main()



















    
