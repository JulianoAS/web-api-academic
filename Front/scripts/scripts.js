
   
    var tbody = document.querySelector('table tbody');
    var pessoa = {};


	    	function Cadastrar(){		
		      var n = document.querySelector('#nome').value; 	

		       pessoa.Nome = document.querySelector('#nome').value;


              if(pessoa.Id === undefined || pessoa.Id === 0){
		       	carregar_pessoas('POST',0,pessoa)  	
              }
              else{
                  carregar_pessoas('PUT',pessoa.Id,pessoa)  	
                  titulo.textContent = `Editar Aluno ${pessoa.Nome}`; 
               }


		    }

		        function excluirPessoa(id){
                    carregar_pessoas('DELETE',id) 
                }
     

		   function Cancelar(){
 
               var btnSalvar =document.querySelector('#btnSalvar');
		     	var btnCancelar = document.querySelector('#btnCancelar');
                var titulo = document.querySelector('#titulo');

                 document.querySelector('#nome').value = ' ';

		     	btnSalvar.textContent = 'Cadastrar';
		     	btnCancelar.textContent = 'Limpar';

		    	titulo.textContent = 'Cadastrar Aluno';

		    	pessoa = {}

		    }

	    

		   function carregar_pessoas(metodo,id,corpo){
               tbody.innerHTML = '';

                 var xhr = new XMLHttpRequest();

                 if(id === undefined || id === 0) id ='';

		        	xhr.open(metodo,`https://localhost:44314/api/pessoa/${id}`, true );

		         	xhr.onload = function() {
		        	var pessoas =JSON.parse(this.responseText);
		   		for (var indice in pessoas)
		   	    	{
		   	 	    	adcionarlinha(pessoas[indice]);
		   	    	}
		     	}

		     	if(corpo !== undefined)
		     	{

                   xhr.setRequestHeader('content-type', 'application/json')
                   xhr.send(JSON.stringify(corpo))

		     	}
		     	else
		     	{

                   xhr.send();

		     	}		    

		   }

         

		   carregar_pessoas('GET');

		   function editarPessoa(_pessoa){
		        var btnSalvar =document.querySelector('#btnSalvar');
		    	var btnCancelar = document.querySelector('#btnCancelar');


		    	document.querySelector('#nome').value = _pessoa.Nome 
                pessoa = _pessoa;

		    	btnSalvar.textContent = 'Salvar';
		    	btnCancelar.textContent = 'Cancelar';
                titulo.textContent = `Editar Aluno ${pessoa.Nome}` ;      

		   }

		   function adcionarlinha(pessoa){
          
                var trow = `<tr>
                       <td>${pessoa.Nome}</td>
                      <td><button onclick='editarPessoa(${JSON.stringify(pessoa)})'>Editar</button></td>
                      <td><button onclick='excluirPessoa(${pessoa.Id})'>Excluir</button></td>
                    </tr>
                    ` 
                tbody.innerHTML += trow;

                    
             }


    
	