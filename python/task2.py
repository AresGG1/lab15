def write(lst):
    fstream = open(file="task2.txt", mode="w")
    st = ""
    count = 0
    for i in lst:
        st += str(i)
        st += ","
        count += 1
        if(count == 7):
            st = st[:-1]+"\n"
            count = 0
    st = st[:-1]
    fstream.write(st)
    fstream.close()

def read():
    fstream = open(file="task2.txt", mode="r")
    st = fstream.read()
    st = st.replace("\n", ",")
    st_array = st.split(',')
    return st_array


def menu():
    while(True):
        lst = []
        opt = input("1 - Read list\n2 - Write list\nq - Leave ")
        if opt == "1":
            lst = read()
        elif opt == "2":
            l = []
            r = []
            num = int(input("Enter number of elements: "))
            for i in range(1, num+1):
                l.append(i)
                if (num-i != 0):
                    r.append(num-i)
            lst = l+r
            write(lst)
        elif opt == "q":
            break
        print(*lst)


menu()
