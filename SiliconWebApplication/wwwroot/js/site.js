
document.addEventListener("DOMContentLoaded", function () {
    const nav = document.querySelector("#nav");
    const abrir = document.querySelector("#abrir");
    const cerrar = document.querySelector("#cerrar");

  
    abrir.addEventListener("click", () => {
        nav.classList.add("visible");
        abrir.style.display = "none";
        cerrar.style.display = "block";
    });

    cerrar.addEventListener("click", () => {
        nav.classList.remove("visible");
        abrir.style.display = "block";
        cerrar.style.display = "none";
    });

    window.addEventListener("resize", () => {
        if (window.innerWidth >= 992) {
            abrir.style.display = "none";
            nav.classList.remove("visible");
            cerrar.style.display = "none";
        } else {
            abrir.style.display = "block";
        }
    });
});

/* -------Dark Mode & Light Mode-------------------*/


document.addEventListener('DOMContentLoaded', function () {
    let sw = document.querySelector('#switch-mode');

    sw.addEventListener('change', function () {
        let theme = this.checked ? "dark" : "light";

        fetch(`/sitesettings/changetheme?mode=${theme}`)
            .then(res => {
                if (res.ok) {
                    window.location.reload();
                } else {
                    console.log('Something went wrong while processing the request.');
                }
            })
            .catch(error => {
                console.error('Error making the AJAX request:', error);
            });
    });
  
    let themeMode = document.cookie.replace(/(?:(?:^|.*;\s*)ThemeMode\s*\=\s*([^;]*).*$)|^.*$/, "$1");
    let switchMode = document.getElementById('switch-mode');
    if (themeMode === "dark") {
        switchMode.checked = true;
    }
});

/*----------------------------TOKEN-----------------------------------*/



//Hämta våra token


fetch('https://localhost:7086/api/auth', {
    method: 'Post'

})
    .then(res => res.text())
    .then(token => {
        sessionStorage.setItem('accesToken', token)
    })



//Hämta det som man vill ha och sätta våra accestoken
fetch('https://localhost:7086/api/course', {
    method: 'get',
    headers: {
        'authorization': `Bearer ${sessionStorage.getItem('accesToken')}`
    }
})
    .then(res => res.json())
    .then(data => {
        console.log(data)
    })


//----------------------- ALL CATEGORIES--------------------






document.addEventListener('DOMContentLoaded', function () {
    select()
    searchQuery()
})

function select() {
    try {
        let select = document.querySelector('.select')
        let selected = select.querySelector('.selected')
        let selectOptions = select.querySelector('.select-options')

        selected.addEventListener('click', function () {
            selectOptions.style.display = (selectOptions.style.display === 'block') ? 'none' : 'block'
        }) 

        let options = selectOptions.querySelectorAll('.option')
        options.forEach(function (option) {
            option.addEventListener('click', function () {
                selected.innerHTML = this.textContent
                selectOptions.style.display = 'none'
                let category = this.getAttribute('data-value')
                selected.setAttribute('data-value', category)
                updateCourseByFilter()
            })
        })

    } catch { }
}


function searchQuery() {
    try {

        document.querySelector('#searchQuery').addEventListener('keyup', function () {
           
            updateCourseByFilter(value)

        })

    } catch { }
}





function updateCourseByFilter() {
    const category = document.querySelector('.select .selected').getAttribute('data-value') || 'all'
    const searchQuery = document.querySelector('#searchQuery').value 

    const url = `/courses/courses?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchQuery)}`


    fetch(url)
        .then(res => res.text())
        .then(data => {
            const parser = new DOMParser()
            const dom = parser.parseFromString(data, 'text/html')
            document.querySelector('.items').innerHTML = dom.querySelector('.items').innerHTML


            const pagination = dom.querySelector('.pagination') ? dom.querySelector('.pagination').innerHTML : ''

            document.querySelector('.pagination').innerHTML = pagination
        })
}




//-----------------UPLOADFIL----------------------------

document.addEventListener('DOMContentLoaded', function () {

    ProfileImageUpload()

})

function ProfileImageUpload() {
    try {
        let UploadFile = document.querySelector('#UploadFile')

        if (UploadFile != undefined) {
            UploadFile.addEventListener('change', function () {
                if (this.files.length > 0)
                    this.form.submit()
            })
        }


    } catch {
        console.error(error)
    }
}
