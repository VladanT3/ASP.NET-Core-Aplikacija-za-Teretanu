function povecajKolicinu(id) {
    const kolicina = document.getElementById(id)
    kolicina.value = parseInt(kolicina.value) + 1
}
function smanjiKolicinu(id) {
    const kolicina = document.getElementById(id)
    let kol = parseInt(kolicina.value)
    if (kol == 1)
        return
    kolicina.value = kol - 1
}