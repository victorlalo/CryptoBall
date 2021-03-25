import os

def enumerate_files(file_dir, file_prefix, file_type_suffix):
    for count, filename in enumerate(os.listdir(file_dir)):
        #print(str(count) + ": " + filename)
        file_dir = file_dir + '/'
        dst = file_prefix + str(count) + file_type_suffix
        src = file_dir + filename
        dst = file_dir + dst

        os.rename(src, dst)

if __name__ == '__main__':
    #enumerate_files('./Assets/Bodies', "B", ".png")
    #enumerate_files('./Assets/Legs', "L", ".png")
    enumerate_files('./Assets/Arms', "A", ".png")
