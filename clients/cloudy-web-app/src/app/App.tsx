import { Flowbite } from 'flowbite-react';
import { MyNavBar } from './../components';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { AccountList } from './../features';
import NoPage from './no-page';
import Home from './home';

const router = createBrowserRouter([
  { path: "/", element: <Home /> },
  { path: "/accounts", element: <AccountList /> },
  { path: "/*", element: <NoPage /> },
]);

function App() {
  return (
    <Flowbite>
      <div className="flex flex-col h-screen overflow-hidden">
        <MyNavBar />
        <div className='flex-grow overflow-auto dark:bg-gray-900 px-4 py-4'>
          <RouterProvider router={router} />
        </div>
      </div>
    </Flowbite>
  );
}

export default App;