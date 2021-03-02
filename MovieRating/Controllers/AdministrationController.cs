//using microsoft.aspnetcore.authorization;
//using microsoft.aspnetcore.identity;
//using microsoft.aspnetcore.mvc;
//using movierating.models;
//using movierating.models.viewmodels;
//using system;
//using system.collections.generic;
//using system.linq;
//using system.threading.tasks;

//namespace movierating.controllers
//{
//    public class administrationcontroller : controller
//    {
//        private readonly rolemanager<identityrole> rolemanager;
//        //private readonly usermanager<userdetails> _usermanager;

//        public administrationcontroller(rolemanager<identityrole> rolemanager)
//        {
//            this.rolemanager = rolemanager;
//        }





//        [httpget]
//        public iactionresult listroles()
//        {
//            var roles = rolemanager.roles;
//            return view(roles);
//        }

//        [httpget]
//        public iactionresult createingrole()
//        {
//            return view();
//        }

//        [httppost]
//        public async task<iactionresult> createingrole(createroleviewmodel model)
//        {
//            if (modelstate.isvalid)
//            {
//                // we just need to specify a unique role name to create a new role
//                identityrole identityrole = new identityrole
//                {
//                    name = model.rolename
//                };

//                // saves the role in the underlying aspnetroles table
//                identityresult result = await rolemanager.createasync(identityrole);

//                if (result.succeeded)
//                {
//                    return redirecttoaction("index", "home");
//                }

//                foreach (identityerror error in result.errors)
//                {
//                    modelstate.addmodelerror("", error.description);
//                }
//            }

//            return view(model);
//        }


//    }
//}
