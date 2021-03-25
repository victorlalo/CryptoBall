from PIL import Image, ImageOps, ImageDraw
from random import randint
import os

asset_dir = './Assets'

def create_new_robot_image(asset_dir, output_name, output_dir):
    # Get indices for all parts (both arms are the same index)
    head_idx = randint(0, len(os.listdir('./Assets/Heads')) - 1)
    bod_idx = randint(0, len(os.listdir('./Assets/Bodies')) - 1)
    arm_idx = randint(0, len(os.listdir('./Assets/Arms')) - 1)
    leg_idx = randint(0, len(os.listdir('./Assets/Legs')) - 1)

    # Open the files by index. Make sure the image names are formatted properly
    head = Image.open('./Assets/Heads/H' + str(head_idx) + '.png')
    bod = Image.open('./Assets/Bodies/B' + str(bod_idx) + '.png')
    arm_r = Image.open('./Assets/Arms/A' + str(arm_idx) + '.png')
    arm_l = arm_r.copy()
    arm_l = ImageOps.mirror(arm_r) # flip the left arm (all arm sprites are right arms)
    legs = Image.open('./Assets/Legs/L' + str(leg_idx) + '.png')

    # Align and Center
    arm_width = arm_l.size[0]
    head_width_align = int((bod.size[0] - head.size[0])/2) + arm_width
    leg_width_align = int((bod.size[0] - legs.size[0])/2) + arm_width
    arm_r_width_align = arm_l.size[0] + bod.size[0]
    body_height_align = head.size[1]
    leg_height_align = head.size[1] + bod.size[1]
    arm_height_align = head.size[1]

    # Create new composite image to populate
    combo = Image.new("RGBA", (arm_width*2 + bod.size[0], head.size[1] + bod.size[1] + legs.size[1]))

    combo.paste(head, (head_width_align, 0))
    combo.paste(bod, (arm_width, body_height_align))
    combo.paste(legs, (leg_width_align, leg_height_align))
    combo.paste(arm_l, (0, arm_height_align))
    combo.paste(arm_r, (arm_r_width_align, arm_height_align))

    # combo.show()
    if '.png' not in output_name:
        output_name += '.png'
    if output_dir[-1] != '/':
        output_dir += '/'

    combo.save(output_dir + output_name)


if __name__ == '__main__':
    for i in range(5):
        create_new_robot_image(asset_dir, 'r'+ str(i), asset_dir + '/Generated_Robots')


