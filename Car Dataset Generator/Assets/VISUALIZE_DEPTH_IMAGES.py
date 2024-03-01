import os
os.environ["OPENCV_IO_ENABLE_OPENEXR"]="1"
import cv2
from matplotlib import pyplot as plt
import numpy as np

PATH_TO_EXR_FILE = "/Users/isaac/Library/Application Support/DefaultCompany/Car Dataset Generator/solo_44/sequence.0/step0.camera.Depth.exr"
im = cv2.imread(PATH_TO_EXR_FILE, cv2.IMREAD_ANYCOLOR | cv2.IMREAD_ANYDEPTH,)
# depth info is stored in "R" channel
im = im[:, :, 2]
# normalizing values between 0 and 1
im -= im.min()
im /= im.max()
plt.imshow(im)
