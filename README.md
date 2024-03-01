# Car Dataset Generator
![](https://media.licdn.com/dms/image/D5622AQFf3N3VC0z3PA/feedshare-shrink_2048_1536/0/1706565996052?e=1712188800&v=beta&t=LrJ9n6ekVjT00VU4HbP08xshddz9wppS-GkApn3Rt9k)

Welcome to the car dataset generator!\
This project implements the [Perception](https://docs.unity3d.com/Packages/com.unity.perception@1.0/manual/index.html) package inside Unity to generate labeled datasets to train self-driving cars, smart traffic lights, and a diverse range of transit-based models! \
Some useful features of this project are:
- World Randomization
  - time of day
  - car placement
  - car type
  - camera placement
- Diverse Labeled Data Types
  - Car + Street Segmentation
  - Car classification
  - Car Bounding Boxes
  - per-pixel depth from Camera
- Fast, Local Generation!
  - No GPU rig required
  - hundreds of labeled images in seconds

Here is a visualization of a dataset being generated real-time.
![](https://media.licdn.com/dms/image/D5622AQEqdAcRO7utxQ/feedshare-shrink_2048_1536/0/1706565992114?e=1712188800&v=beta&t=i81vQs1oNeulxl-vvxsI-XWoroTSc94MFwvFIrouM4k)




example 1: evening, driver cam
<p float="left">
  <img src="https://media.licdn.com/dms/image/D5622AQGHcXTl-vvkLw/feedshare-shrink_800/0/1706565991045?e=1712188800&v=beta&t=4jKNAMS7flJgeUxZDY0Vpt4wXOcgaWtXEMKf_4VXOq4" width="200" />
  <img src="https://media.licdn.com/dms/image/D5622AQG_rl9mmmezXA/feedshare-shrink_800/0/1706565990920?e=1712188800&v=beta&t=i1muHlIdbBoxuX5lb-HywpUi1gkEb6W4-c9lf2PGK1o" width="200" />
  <img src="https://media.licdn.com/dms/image/D5622AQHWtXlk4KhhjQ/feedshare-shrink_800/0/1706565990832?e=1712188800&v=beta&t=Y5RlIHmcpQ1mraKR4_cmjPBm-ck1BbunslIw20IlCkQ" width="200" />
  <img src="https://media.licdn.com/dms/image/D5622AQFd8hQoP6vzFA/feedshare-shrink_800/0/1706565990787?e=1712188800&v=beta&t=mChhV_XQJyxe0QcZGfEr33MVpTsptJxugSdjLA-ELGI" width="200" />
</p>
example 2: night time, front view
<p float="left">
  <img src="https://media.licdn.com/dms/image/D5622AQFKAui3RykVfw/feedshare-shrink_800/0/1706565990802?e=1712188800&v=beta&t=qVqQiGcpcRHC6FiUJuLtVtIfV7XbASJIR8ZSeeAYPtg" width="200" />
  <img src="https://media.licdn.com/dms/image/D5622AQFreNO_8GhRug/feedshare-shrink_800/0/1706565990792?e=1712188800&v=beta&t=vt7wb2lRZzvY8cl0xo1o3-Qtem5jtwpe5wCTijb3Dmk" width="200" />
  <img src="https://media.licdn.com/dms/image/D5622AQHPJACQbz5mZQ/feedshare-shrink_800/0/1706565990863?e=1712188800&v=beta&t=ljGwI7T0foVOKUbHrTDeVdItlNTwSV1Gq5UipAiIUsU" width="200" />
  <img src="https://media.licdn.com/dms/image/D5622AQFlmTMANHDvFw/feedshare-shrink_800/0/1706565990786?e=1712188800&v=beta&t=EJ2rVznNlFrrK2dIQ3HpzO3oXImPZ2KSRQtI0IuAhts" width="200" />
</p>

example 3: evening, top view
<p float="left">
  <img src="https://media.licdn.com/dms/image/D5622AQHcsGhutYheeQ/feedshare-shrink_800/0/1706565991101?e=1712188800&v=beta&t=8FgcT8qCJGffb_uRw331k9VF-nPDhF2anxotvcEs1pc" width="200" />
  <img src="https://media.licdn.com/dms/image/D5622AQF7nL2iPFPk5w/feedshare-shrink_800/0/1706565991009?e=1712188800&v=beta&t=h5xSpKOxUoQliGUhqjg98_Sa28pJ7aruQksmfDnjGVg" width="200" />
  <img src="https://media.licdn.com/dms/image/D5622AQGeorOL4OwFLw/feedshare-shrink_800/0/1706565990830?e=1712188800&v=beta&t=eCnrMBgcLbmeEYbW1gHo9TodBmbK6ojfR_vIIwV1Jo8" width="200" />
  <img src="https://media.licdn.com/dms/image/D5622AQFM_TBXNIpmjQ/feedshare-shrink_800/0/1706565990821?e=1712188800&v=beta&t=uNVvnh8npFXA_UzPWQWUc1sOyTgX3xBEJH9XnIk4I2E" width="200" />

</p>
