function getParameterDefinitions() {
  return [
    { name: 'youki_size', type: 'float', initial: 60, caption: "容器のサイズ:" },
    { name: 'soko_atusa', type: 'float', initial: 2, caption: "容器の底の厚さ:" },
    { name: 'youki_kabe_atusa', type: 'float', initial: 2,caption: "容器の壁の厚さ" },
    { name: 'youki_kabe_atusa', type: 'float', initial: 2,caption: "容器の壁の高さ" },    
    { name: 'youki_kuudou_atusa', type: 'float', initial: 4,caption: "容器の穴の深さ" }    
  ];
}

function main(p) {
    let kuudou = cube([p.youki_size,p.youki_size,p.youki_kuudou_atusa]).translate([-p.youki_size/2,-p.youki_size/2,p.soko_atusa]);
    p.youki_size += p.youki_kabe_atusa*2;
    let youki = cube([p.youki_size,p.youki_size,p.soko_atusa+p.youki_kuudou_atusa+10]).translate([-p.youki_size/2,-p.youki_size/2,0]);
    p.youki_size -= p.youki_kabe_atusa*2;
    let image = makeimage(-p.youki_size/2,-p.youki_size/2,p.soko_atusa,p.youki_size);
    youki = difference(youki,kuudou);
    return union(youki,image);
}

function getParameterDefinitions() {
  return [
    { name: 'youki_size', type: 'float', initial: 60, caption: "容器のサイズ:" },
    { name: 'soko_atusa', type: 'float', initial: 2, caption: "容器の底の厚さ:" },
    { name: 'youki_kabe_atusa', type: 'float', initial: 2,caption: "容器の壁の厚さ" },
    { name: 'youki_kabe_takasa', type: 'float', initial: 4,caption: "容器の壁の高さ" },    
    { name: 'youki_kuudou_atusa', type: 'float', initial: 4,caption: "容器の穴の深さ" }    
  ];
}

function main(p) {
    let kuudou = cube([p.youki_size,p.youki_size,p.youki_kuudou_atusa-4+p.youki_kabe_takasa]).translate([-p.youki_size/2,-p.youki_size/2,p.soko_atusa]);
    p.youki_size += p.youki_kabe_atusa*2;
    let youki = cube([p.youki_size,p.youki_size,p.soko_atusa+p.youki_kuudou_atusa-4+p.youki_kabe_takasa]).translate([-p.youki_size/2,-p.youki_size/2,0]);
    p.youki_size -= p.youki_kabe_atusa*2;
    let image = makeimage(-p.youki_size/2,-p.youki_size/2,p.soko_atusa,p.youki_size);    
    youki = difference(youki,kuudou);
    return union(youki,image);
}
