import { Flowbite } from 'flowbite-react';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';

import { MyNavBar } from './../components';
import { AccountDirectory, AccountList } from './../features';
import NoPage from './NoPage';
import Home from './Home';

const router = createBrowserRouter([
  { path: "/", element: <Home /> },
  { path: "/accounts", element: <AccountList /> },
  { path: "/accounts/:id", element: <AccountDirectory /> },
  { path: "/*", element: <NoPage /> },
]);

// const queryClient = new QueryClient();


// export const store = configureStore({
//   reducer: {},
// });


function App() {
  return (
    // <Provider store={store}>
    <Flowbite>
      {/* <QueryClientProvider client={queryClient}> */}
      <div className="flex flex-col h-screen overflow-hidden">
        <MyNavBar />
        <div className='flex-grow overflow-auto dark:bg-gray-900 px-4 py-4'>
          <RouterProvider router={router} />
        </div>
      </div>
      {/* </QueryClientProvider> */}
    </Flowbite>
    // </Provider >
  );
}

export default App;