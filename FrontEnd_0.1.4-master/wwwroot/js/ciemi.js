let novads = document.getElementById("novadiIDCiemi");
novads.addEventListener("change", function () {
    let url = "/Home/Excel?novadsID=" + novads.value;
    document.getElementById("atlasitCiemi").href = url;
})

document.getElementById("attir").addEventListener("click", function () {
    let defaultOption = document.getElementsByClassName("defaultOption");

    for (let i = 0; i < defaultOption.length; i++) {
        defaultOption.item(i).selected = true;
    }
});