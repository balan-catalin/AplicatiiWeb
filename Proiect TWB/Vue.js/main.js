

var app = new Vue({
  el: "#app",
  data: {
    listaDepartemente: [],
    listaAngajati: [],
    errors: [],
    dep: { Marca: '', name: '' },
    listAng: []
  },
  created() {
      axios.get(`http://localhost:49854/api/Angajats/GetAngajats`)
          .then(response => {
              this.listaAngajati = response.data
          })
          .catch(e => {
              this.errors.push(e)
          });
      axios.get(`http://localhost:49854/api/Departaments/GetDepartaments`)
          .then(response => {
              this.listaDepartemente = response.data
          })
          .catch(e => {
              this.errors.push(e)
          });
    },
    methods: {
        click: function (angajat) {
            this.dep.name = angajat.Departament.DenumireDep;
            this.dep.Marca = angajat.Marca;
        },
        clickDep: function (departament) {
            axios.get('http://localhost:49854/api/Angajats/?id=' + departament.idDep 
            )
                .then(response => {
                    this.listAng = response.data
                    console.log(listAng)
                })
                .catch(e => {
                    this.errors.push(e)
                });
        }
    }
})
