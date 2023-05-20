const prikazSifre = document.getElementById('prikazSifre');
const sifra = document.getElementById('inputSifra');

prikazSifre.addEventListener("change", function () {
    if (prikazSifre.checked)
        sifra.type = 'text';
    else
        sifra.type = 'password';
});