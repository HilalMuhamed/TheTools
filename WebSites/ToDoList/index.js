const tl= gsap.timeline({defaults:{ease:"power1.out"}})

tl.to(".text",{y:"0%",duration: 1 ,stagger :0.5});
tl.to(".slider",{y:"-100%",duration:2,delay:0.5});
tl.to(".intro",{y:"-100%",duration:1},"-=1.5");//-=1 start 1 second faster
tl.fromTo('nav',{opacity:0},{opacity:1,duration:1});
tl.fromTo('.bigtext',{opacity:0},{opacity:1,duration:2},"-=1");