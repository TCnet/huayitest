var amount,timer
function scroll(){
amount=arguments[0]
timer=setInterval("demo.scrollLeft+=amount",arguments[1])
}
function stop(){
clearInterval(timer)
}